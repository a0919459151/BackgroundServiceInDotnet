using BackgroundServiceInDotnet.GeneralServices.MailSender;

namespace BackgroundServiceInDotnet.HostedServices;

public class EmailSenderBackgroundService : BackgroundService
{
    private readonly IEmailQueueService _emailQueueService;
    private readonly ILogger<EmailSenderBackgroundService> _logger;
    private readonly IEmailSender _emailSender;

    public EmailSenderBackgroundService(IEmailQueueService emailQueueService, ILogger<EmailSenderBackgroundService> logger, IEmailSender emailSender)
    {
        _emailQueueService = emailQueueService;
        _logger = logger;
        _emailSender = emailSender;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            while (_emailQueueService.TryDequeue(out var message))
            {
                try
                {
                    _logger.LogInformation("Exec mail");
                    await _emailSender.SendEmailAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send email to {To}", message.To);
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // Wait for 5 seconds
        }
    }
}


