namespace BackgroundServiceInDotnet.GeneralServices.MailSender;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(EmailMessage message)
    {
        _logger.LogInformation("Email is sent");
        await Task.Delay(3000);
    }
}
