using BackgroundServiceInDotnet.GeneralServices.MailSender;
using BackgroundServiceInDotnet.HostedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Ioc services
builder.Services.AddSingleton<IEmailQueueService, EmailQueueService>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Register the hosted service
builder.Services.AddHostedService<EmailSenderBackgroundService>();
builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
