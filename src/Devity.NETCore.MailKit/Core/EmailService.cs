using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devity.NETCore.MailKit.Infrastructure.Internal;
using Devity.NETCore.MailKit.Shared;
using MimeKit;
using MimeKit.Text;

namespace Devity.NETCore.MailKit.Core
{
    public class EmailService : IEmailService
    {
        private readonly IMailKitProvider _MailKitProvider;

        public EmailService(IMailKitProvider provider)
        {
            _MailKitProvider = provider;
        }

        /// <summary>
        /// send email with UTF-8
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public void Send(
            string mailTo,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, sender);
        }

        /// <summary>
        /// send email
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="encoding">email message encoding</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public void Send(
            string mailTo,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(mailTo, null, null, subject, message, encoding, isHtml, sender);
        }

        /// <summary>
        /// send email with UTF-8
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="mailCc">send cc,multi split with ","</param>
        /// <param name="mailBcc">send bcc,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, sender);
        }

        /// <summary>
        /// send email
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="mailCc">send cc,multi split with ","</param>
        /// <param name="mailBcc">send bcc,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="encoding">email message encoding</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(mailTo, mailCc, mailBcc, subject, message, encoding, isHtml, sender);
        }

        public void Send(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(
                mailTo,
                null,
                null,
                subject,
                message,
                Encoding.UTF8,
                isHtml,
                sender,
                attachments
            );
        }

        public void Send(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(mailTo, null, null, subject, message, encoding, isHtml, sender, attachments);
        }

        public void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(
                mailTo,
                mailCc,
                mailBcc,
                subject,
                message,
                Encoding.UTF8,
                isHtml,
                sender,
                attachments
            );
        }

        public void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            SendEmail(
                mailTo,
                mailCc,
                mailBcc,
                subject,
                message,
                encoding,
                isHtml,
                sender,
                attachments
            );
        }

        /// <summary>
        /// send email with UTF-8 async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public Task SendAsync(
            string mailTo,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, sender);
            });
        }

        /// <summary>
        /// send email async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="encoding">email message encoding</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public Task SendAsync(
            string mailTo,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(mailTo, null, null, subject, message, encoding, isHtml, sender);
            });
        }

        /// <summary>
        /// send email with UTF-8 async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="mailCc">send cc,multi split with ","</param>
        /// <param name="mailBcc">send bcc,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, sender);
            });
        }

        /// <summary>
        /// send email async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="mailCc">send cc,multi split with ","</param>
        /// <param name="mailBcc">send bcc,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="encoding">email message encoding</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        public Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(mailTo, mailCc, mailBcc, subject, message, encoding, isHtml, sender);
            });
        }

        public Task SendAsync(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(
                    mailTo,
                    null,
                    null,
                    subject,
                    message,
                    Encoding.UTF8,
                    isHtml,
                    sender,
                    attachments
                );
            });
        }

        public Task SendAsync(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(
                    mailTo,
                    null,
                    null,
                    subject,
                    message,
                    encoding,
                    isHtml,
                    sender,
                    attachments
                );
            });
        }

        public Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(
                    mailTo,
                    mailCc,
                    mailBcc,
                    subject,
                    message,
                    Encoding.UTF8,
                    isHtml,
                    sender,
                    attachments
                );
            });
        }

        public Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            string[] attachments,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendEmail(
                    mailTo,
                    mailCc,
                    mailBcc,
                    subject,
                    message,
                    encoding,
                    isHtml,
                    sender,
                    attachments
                );
            });
        }

        public void SendMultipart(
            string mailTo,
            string subject,
            string htmlMessage,
            string plainTextMessage,
            string[] attachments = null,
            SenderInfo sender = null,
            IDictionary<string, string> extraHeaders = null
        )
        {
            SendMultipartEmail(mailTo, subject, htmlMessage, plainTextMessage, sender, attachments, extraHeaders);
        }

        public Task SendMultipartAsync(
            string mailTo,
            string subject,
            string htmlMessage,
            string plainTextMessage,
            string[] attachments = null,
            SenderInfo sender = null,
            IDictionary<string, string> extraHeaders = null
        )
        {
            return Task.Factory.StartNew(() =>
            {
                SendMultipartEmail(mailTo, subject, htmlMessage, plainTextMessage, sender, attachments, extraHeaders);
            });
        }

        /// <summary>
        /// builds and sends a multipart/alternative (HTML + plain-text) message, optionally
        /// wrapped in multipart/mixed if attachments are present - mirrors <see cref="SendEmail"/>
        /// but with a TextPart for each of the html/plain-text bodies instead of just one.
        /// </summary>
        private void SendMultipartEmail(
            string mailTo,
            string subject,
            string htmlMessage,
            string plainTextMessage,
            SenderInfo sender = null,
            string[] attachments = default,
            IDictionary<string, string> extraHeaders = null
        )
        {
            var _to = new string[0];
            if (!string.IsNullOrEmpty(mailTo))
                _to = mailTo.Split(',').Select(x => x.Trim()).ToArray();

            Check.Argument.IsNotEmpty(_to, nameof(mailTo));
            Check.Argument.IsNotEmpty(htmlMessage, nameof(htmlMessage));
            Check.Argument.IsNotEmpty(plainTextMessage, nameof(plainTextMessage));

            using var mimeMessage = new MimeMessage();

            //add mail from
            if (
                !string.IsNullOrEmpty(sender?.SenderEmail)
                && !string.IsNullOrEmpty(sender?.SenderName)
            )
            {
                mimeMessage.From.Add(new MailboxAddress(sender.SenderName, sender.SenderEmail));
            }
            else
            {
                mimeMessage.From.Add(
                    new MailboxAddress(
                        _MailKitProvider.Options.SenderName,
                        _MailKitProvider.Options.SenderEmail
                    )
                );
            }

            //add mail to
            foreach (var to in _to)
            {
                mimeMessage.To.Add(MailboxAddress.Parse(to));
            }

            //add subject
            mimeMessage.Subject = subject;

            //add any additional raw headers (e.g. List-Unsubscribe / List-Unsubscribe-Post)
            if (extraHeaders != null)
            {
                foreach (var header in extraHeaders)
                {
                    mimeMessage.Headers.Add(header.Key, header.Value);
                }
            }

            //add html + plain-text alternative body
            var textBody = new TextPart(TextFormat.Text);
            textBody.SetText(Encoding.UTF8, plainTextMessage);

            var htmlBody = new TextPart(TextFormat.Html);
            htmlBody.SetText(Encoding.UTF8, htmlMessage);

            // order matters: mail clients pick the last part they understand, so html goes last
            Multipart bodyPart = new Multipart("alternative") { textBody, htmlBody };

            MimeEntity finalBody = bodyPart;

            // add attachments
            if (attachments != null && attachments.Length > 0)
            {
                var multipartBody = new Multipart("mixed") { bodyPart };
                foreach (var attach in attachments)
                {
                    var mimeType = MimeTypes.GetMimeType(attach).Split('/');
                    multipartBody.Add(
                        new MimePart(mimeType[0], mimeType[1])
                        {
                            IsAttachment = true,
                            Content = new MimeContent(
                                File.OpenRead(attach),
                                ContentEncoding.Default
                            ),
                            ContentDisposition = new ContentDisposition(
                                ContentDisposition.Attachment
                            ),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = Path.GetFileName(attach),
                        }
                    );
                }
                finalBody = multipartBody;
            }

            //set email body
            mimeMessage.Body = finalBody;

            SendWithSharedClient(mimeMessage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="mailCc"></param>
        /// <param name="mailBcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="encoding"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender">from</param>
        private void SendEmail(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml,
            SenderInfo sender = null,
            string[] attachments = default
        )
        {
            var _to = new string[0];
            var _cc = new string[0];
            var _bcc = new string[0];
            if (!string.IsNullOrEmpty(mailTo))
                _to = mailTo.Split(',').Select(x => x.Trim()).ToArray();
            if (!string.IsNullOrEmpty(mailCc))
                _cc = mailCc.Split(',').Select(x => x.Trim()).ToArray();
            if (!string.IsNullOrEmpty(mailBcc))
                _bcc = mailBcc.Split(',').Select(x => x.Trim()).ToArray();

            Check.Argument.IsNotEmpty(_to, nameof(mailTo));
            Check.Argument.IsNotEmpty(message, nameof(message));

            using var mimeMessage = new MimeMessage();

            //add mail from
            if (
                !string.IsNullOrEmpty(sender?.SenderEmail)
                && !string.IsNullOrEmpty(sender?.SenderName)
            )
            {
                mimeMessage.From.Add(new MailboxAddress(sender.SenderName, sender.SenderEmail));
            }
            else
            {
                mimeMessage.From.Add(
                    new MailboxAddress(
                        _MailKitProvider.Options.SenderName,
                        _MailKitProvider.Options.SenderEmail
                    )
                );
            }

            //add mail to
            foreach (var to in _to)
            {
                mimeMessage.To.Add(MailboxAddress.Parse(to));
            }

            //add mail cc
            foreach (var cc in _cc)
            {
                mimeMessage.Cc.Add(MailboxAddress.Parse(cc));
            }

            //add mail bcc
            foreach (var bcc in _bcc)
            {
                mimeMessage.Bcc.Add(MailboxAddress.Parse(bcc));
            }

            //add subject
            mimeMessage.Subject = subject;

            //add email body
            TextPart body = null;

            if (isHtml)
            {
                body = new TextPart(TextFormat.Html);
            }
            else
            {
                body = new TextPart(TextFormat.Text);
            }
            //set email encoding
            body.SetText(encoding, message);

            //add multipart
            Multipart multipartBody = new Multipart("mixed") { body };

            // add attachments
            if (attachments != null)
                foreach (var attach in attachments)
                {
                    var mimeType = MimeTypes.GetMimeType(attach).Split('/');
                    multipartBody.Add(
                        new MimePart(mimeType[0], mimeType[1])
                        {
                            IsAttachment = true,
                            Content = new MimeContent(
                                File.OpenRead(attach),
                                ContentEncoding.Default
                            ),
                            ContentDisposition = new ContentDisposition(
                                ContentDisposition.Attachment
                            ),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = Path.GetFileName(attach),
                        }
                    );
                }

            //set email body
            mimeMessage.Body = multipartBody;

            SendWithSharedClient(mimeMessage);
        }

        /// <summary>
        /// Sends through <see cref="_MailKitProvider"/>'s shared, reused SmtpClient - never disposed
        /// here, since its connection lifetime is owned by the provider (see MailKitProvider.Dispose),
        /// not by an individual send. Serialized via SmtpLock since that shared client is not safe for
        /// concurrent use (this provider may be a DI singleton reached from multiple requests, or a
        /// caller sending a paced batch on more than one thread).
        /// </summary>
        private void SendWithSharedClient(MimeMessage mimeMessage)
        {
            _MailKitProvider.SmtpLock.Wait();
            try
            {
                _MailKitProvider.SmtpClient.Send(mimeMessage);
            }
            finally
            {
                _MailKitProvider.SmtpLock.Release();
            }
        }
    }
}
