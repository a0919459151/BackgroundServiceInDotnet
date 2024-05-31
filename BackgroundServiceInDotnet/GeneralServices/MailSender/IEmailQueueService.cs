namespace BackgroundServiceInDotnet.GeneralServices.MailSender;

public interface IEmailQueueService
{
    void QueueEmail(EmailMessage message);
    bool TryDequeue(out EmailMessage message);
}
