using EmailSenderService;
using Microsoft.AspNetCore.Identity.UI.Services;

public class EmailSenderUtil : IEmailSender
{
    private readonly EmailService _emailService;

    public EmailSenderUtil(
        EmailService emailService
    )
    {
        _emailService = emailService;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        await _emailService.SendEmailAsync(
            email,
            subject,
            htmlMessage
        );
    }
}