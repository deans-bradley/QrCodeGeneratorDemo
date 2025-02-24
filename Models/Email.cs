using SendGrid.Helpers.Mail;

namespace QrCodeGeneratorDemo.Models
{
    public class Email
    {
        public Email(EmailAddress from, EmailAddress to, string subject, string body, Attachment attatchment)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
            Attatchment = attatchment;
        }

        public EmailAddress To { get; set; } = new EmailAddress();
        public EmailAddress From { get; set; } = new EmailAddress();
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
        public Attachment Attatchment { get; set; } = new Attachment();
    }
}

