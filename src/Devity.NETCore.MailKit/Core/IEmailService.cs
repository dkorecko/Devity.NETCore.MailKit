using System.Text;
using System.Threading.Tasks;
using Devity.NETCore.MailKit.Infrastructure.Internal;

namespace Devity.NETCore.MailKit.Core
{
    public interface IEmailService
    {
        /// <summary>
        /// send email with UTF-8
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        void Send(
            string mailTo,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email with UTF-8
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="attachments"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        void Send(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="encoding">email message encoding</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        void Send(
            string mailTo,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="attachments"></param>
        /// <param name="encoding"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        void Send(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

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
        void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email with UTF-8
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="mailCc"></param>
        /// <param name="mailBcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="attachments"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        );

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
        void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="mailCc"></param>
        /// <param name="mailBcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="attachments"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        void Send(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email with UTF-8 async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        Task SendAsync(
            string mailTo,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email with UTF-8 async
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="attachments"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        Task SendAsync(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="message">email message</param>
        /// <param name="encoding">email message encoding</param>
        /// <param name="isHtml">is set message as html</param>
        /// <param name="sender">from</param>
        Task SendAsync(
            string mailTo,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email async
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="attachments"></param>
        /// <param name="encoding"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        Task SendAsync(
            string mailTo,
            string subject,
            string message,
            string[] attachments,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

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
        Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send email UTF-8 async
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="mailCc"></param>
        /// <param name="mailBcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="isHtml"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            string[] attachments,
            bool isHtml = false,
            SenderInfo sender = null
        );

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
        Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

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
        Task SendAsync(
            string mailTo,
            string mailCc,
            string mailBcc,
            string subject,
            string message,
            string[] attachments,
            Encoding encoding,
            bool isHtml = false,
            SenderInfo sender = null
        );

        /// <summary>
        /// send a multipart/alternative email (both an HTML and a plain-text body, so clients
        /// that render HTML get the rich version while others fall back to plain text)
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="htmlMessage">the HTML body</param>
        /// <param name="plainTextMessage">the plain-text body</param>
        /// <param name="attachments"></param>
        /// <param name="sender">from</param>
        void SendMultipart(
            string mailTo,
            string subject,
            string htmlMessage,
            string plainTextMessage,
            string[] attachments = null,
            SenderInfo sender = null
        );

        /// <summary>
        /// send a multipart/alternative email (both an HTML and a plain-text body) async
        /// </summary>
        /// <param name="mailTo">consignee email,multi split with ","</param>
        /// <param name="subject">subject</param>
        /// <param name="htmlMessage">the HTML body</param>
        /// <param name="plainTextMessage">the plain-text body</param>
        /// <param name="attachments"></param>
        /// <param name="sender">from</param>
        Task SendMultipartAsync(
            string mailTo,
            string subject,
            string htmlMessage,
            string plainTextMessage,
            string[] attachments = null,
            SenderInfo sender = null
        );
    }
}
