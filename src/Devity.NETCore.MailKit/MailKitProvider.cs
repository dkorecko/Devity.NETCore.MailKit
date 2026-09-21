using System;
using System.Threading;
using Devity.NETCore.MailKit.Infrastructure.Internal;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Devity.NETCore.MailKit
{
    public class MailKitProvider : IMailKitProvider, IDisposable
    {
        public MailKitOptions Options { get; private set; }

        /// <summary>
        /// Serializes access to the shared <see cref="SmtpClient"/> - a single MailKit client is not
        /// safe for concurrent use, and this provider is registered as a DI singleton (see
        /// ServicesCollectionExtensions.AddProviderService) so it can be reached from multiple
        /// concurrent requests. Callers that send through <see cref="SmtpClient"/> should hold this
        /// for the duration of the connect/authenticate/send.
        /// </summary>
        public SemaphoreSlim SmtpLock { get; } = new SemaphoreSlim(1, 1);

        private readonly object _smtpSync = new object();
        private SmtpClient _smtpClient;

        private readonly object _pop3Sync = new object();
        private Pop3Client _pop3Client;

        private readonly object _imapSync = new object();
        private ImapClient _imapClient;

        private bool _disposed;

        public MailKitProvider(MailKitOptions mailKitOptions)
        {
            Options = mailKitOptions;
        }

        #region Smtp

        /// <summary>
        /// The connected/authenticated SMTP client for this provider's <see cref="Options"/>. Reused
        /// across calls (not reconnected every time) as long as the underlying connection is still
        /// alive - a fresh connect+authenticate per send is what a mailbox provider's abuse detection
        /// tends to flag as a compromised-account login pattern. Reconnects transparently if the
        /// connection dropped (e.g. an idle timeout from the server) since a paced/long-running sender
        /// can otherwise hold a stale reference for a while between sends.
        /// </summary>
        public SmtpClient SmtpClient
        {
            get
            {
                lock (_smtpSync)
                {
                    if (_smtpClient == null || !_smtpClient.IsConnected || !_smtpClient.IsAuthenticated)
                    {
                        _smtpClient?.Dispose();
                        _smtpClient = InitSmtpClient();
                    }

                    return _smtpClient;
                }
            }
        }

        private SmtpClient InitSmtpClient()
        {
            var client = new SmtpClient();

            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            if (!Options.Security)
            {
                client.Connect(Options.Server, Options.Port, SecureSocketOptions.None);
            }
            else
            {
                // fix issue #6
                client.Connect(Options.Server, Options.Port, SecureSocketOptions.Auto);
            }

            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            client.AuthenticationMechanisms.Remove("XOAUTH2");

            // user login smtp server (fix issue #9)
            if (!string.IsNullOrEmpty(Options.Account) && !string.IsNullOrEmpty(Options.Password))
            {
                client.Authenticate(Options.Account, Options.Password);
            }

            return client;
        }

        #endregion

        #region Pop3
        public Pop3Client Pop3Client
        {
            get
            {
                lock (_pop3Sync)
                {
                    if (_pop3Client == null || !_pop3Client.IsConnected || !_pop3Client.IsAuthenticated)
                    {
                        _pop3Client?.Dispose();
                        _pop3Client = InitPop3Client();
                    }

                    return _pop3Client;
                }
            }
        }

        private Pop3Client InitPop3Client()
        {
            var client = new Pop3Client();

            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect(Options.Server, Options.Port, Options.Security);

            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            client.AuthenticationMechanisms.Remove("XOAUTH2");

            // user login pop3 server
            client.Authenticate(Options.Account, Options.Password);
            return client;
        }

        #endregion

        #region Imap
        public ImapClient ImapClient
        {
            get
            {
                lock (_imapSync)
                {
                    if (_imapClient == null || !_imapClient.IsConnected || !_imapClient.IsAuthenticated)
                    {
                        _imapClient?.Dispose();
                        _imapClient = InitImapClient();
                    }

                    return _imapClient;
                }
            }
        }

        private ImapClient InitImapClient()
        {
            var client = new ImapClient();

            client.Connect(Options.Server, Options.Port, Options.Security);

            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            // user login imap server
            client.Authenticate(Options.Account, Options.Password);

            return client;
        }
        #endregion

        /// <summary>
        /// Gracefully disconnects (a clean QUIT rather than dropping the socket) and disposes
        /// whichever of the SMTP/POP3/IMAP clients were actually opened.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            lock (_smtpSync)
            {
                DisconnectQuietly(_smtpClient);
                _smtpClient = null;
            }

            lock (_pop3Sync)
            {
                DisconnectQuietly(_pop3Client);
                _pop3Client = null;
            }

            lock (_imapSync)
            {
                DisconnectQuietly(_imapClient);
                _imapClient = null;
            }

            SmtpLock.Dispose();
        }

        private static void DisconnectQuietly(global::MailKit.MailService client)
        {
            if (client == null)
            {
                return;
            }

            try
            {
                if (client.IsConnected)
                {
                    client.Disconnect(true);
                }
            }
            catch
            {
                // best-effort - the connection may already be broken, nothing more to do
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
