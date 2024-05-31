using System.Collections.Concurrent;

namespace BackgroundServiceInDotnet.GeneralServices.MailSender;

public class EmailQueueService : IEmailQueueService
{
    private readonly ConcurrentQueue<EmailMessage> _emailQueue = new ConcurrentQueue<EmailMessage>();

    public void QueueEmail(EmailMessage message)
    {
        _emailQueue.Enqueue(message);
    }

    public bool TryDequeue(out EmailMessage message)
    {
        return _emailQueue.TryDequeue(out message);
    }
}
