using System.Net;
using System.Net.Mail;

namespace EmailSenderService;
    public class EmailMessage: IEmailMessage
    {
        public List<MailAddress> To { get; set; } = new List<MailAddress>();
        public List<MailAddress> Cc { get; set; } = new List<MailAddress>();
        public List<MailAddress> Bcc { get; set; } = new List<MailAddress>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; } = false;
        public EmailMessage(string subject, string content, IEnumerable<MailAddress> to, bool isHtml = false, IEnumerable<MailAddress>? cc = null, IEnumerable<MailAddress>? bcc = null)
        {
            To.AddRange(to);
            if (cc is not null)
            {
                Cc.AddRange(cc);
            }
            if (bcc is not null)
            {
                Bcc.AddRange(bcc);
            }
            Subject = subject;
            Body = content;  
            IsHtml = isHtml;      
        }
    }

    // create an interface for classe EmailMessage  
    public interface IEmailMessage
    {
        List<MailAddress> To { get; set; }
        List<MailAddress> Cc { get; set; }
        List<MailAddress> Bcc { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        bool IsHtml { get; set; }
    }
