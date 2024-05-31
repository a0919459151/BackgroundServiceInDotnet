namespace BackgroundServiceInDotnet.GeneralServices.MailSender;

public interface IEmailSender
{
    Task SendEmailAsync(EmailMessage message);
}
