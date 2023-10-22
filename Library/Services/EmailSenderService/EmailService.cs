using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace EmailSenderService;

public class EmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly EmailSenderServiceSmtpSettings _emailConfig;

    public EmailService(EmailSenderServiceSmtpSettings emailConfig, ILogger<EmailService> logger)
    {
        _emailConfig = emailConfig;
        _logger = logger;
    }

    /// <summary>
    /// Send an email to a single recipient
    /// Used by AspNet Identity
    /// </summary>
    /// <param name="email"></param>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task SendEmailAsync(string email, string subject, string message)
    {
        IEnumerable<MailAddress> to = new List<MailAddress>() { new MailAddress(email) };
        IEmailMessage emailMessage = new EmailMessage(subject, message, to);

        var mailMessage = CreateEmailMessage(emailMessage);
        return Send(mailMessage);
    }

    public Task SendEmailAsync(IEmailMessage message)
    {
        var mailMessage = CreateEmailMessage(message);
        return Send(mailMessage);
    }

    private MailMessage CreateEmailMessage(IEmailMessage emailMessage)
    {
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(_emailConfig.FromDisplayName, _emailConfig.UserName);
        foreach (var to in emailMessage.To)
        {
            mailMessage.To.Add(to);
        }
        foreach (var cc in emailMessage.Cc)
        {
            mailMessage.CC.Add(cc);
        }
        foreach (var bcc in emailMessage.Bcc)
        {
            mailMessage.Bcc.Add(bcc);
        }
        mailMessage.Subject = emailMessage.Subject;
        mailMessage.Body = emailMessage.Body;
        mailMessage.IsBodyHtml = emailMessage.IsHtml;
        return mailMessage;
    }

    private Task Send(MailMessage mailMessage)
    {
        using (var smtpClient = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.Port))
        {
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(
                _emailConfig.UserName,
                _emailConfig.Password
            );
            smtpClient.EnableSsl = _emailConfig.EnableSsl;

            _logger.LogInformation("SendEmail Async...");
            return smtpClient.SendMailAsync(mailMessage);
        }
    }
}
