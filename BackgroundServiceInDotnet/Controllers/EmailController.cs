using BackgroundServiceInDotnet.GeneralServices.MailSender;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailQueueService _emailQueueService;
    private readonly ILogger<EmailQueueService> _logger;

    public EmailController(IEmailQueueService emailQueueService, ILogger<EmailQueueService> logger)
    {
        _emailQueueService = emailQueueService;
        _logger = logger;
    }

    [HttpPost("send")]
    public IActionResult SendEmail([FromBody] EmailMessage emailMessage)
    {
        _emailQueueService.QueueEmail(emailMessage);
        _logger.LogInformation("Email queued for sending");
        return Ok("Email queued for sending.");
    }
}
