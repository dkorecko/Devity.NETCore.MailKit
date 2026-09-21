using System.Threading;
using Devity.NETCore.MailKit.Infrastructure.Internal;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;

namespace Devity.NETCore.MailKit
{
    public interface IMailKitProvider
    {
        /// <summary>
        /// mailkit options
        /// </summary>
        MailKitOptions Options { get; }

        /// <summary>
        /// smtp client - reused across calls while the connection stays alive, so callers that send
        /// through it should hold <see cref="SmtpLock"/> for the duration of the send
        /// </summary>
        SmtpClient SmtpClient { get; }

        /// <summary>
        /// serializes access to the shared <see cref="SmtpClient"/>, which is not safe for
        /// concurrent use from multiple callers
        /// </summary>
        SemaphoreSlim SmtpLock { get; }

        /// <summary>
        /// pop3 client
        /// </summary>
        Pop3Client Pop3Client { get; }

        /// <summary>
        /// imap client
        /// </summary>
        ImapClient ImapClient { get; }
    }
}
