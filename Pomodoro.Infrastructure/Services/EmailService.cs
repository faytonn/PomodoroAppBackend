using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Pomodoro.Application.DTOs.Email;
using Pomodoro.Application.Interfaces.Services;

namespace Pomodoro.Infrastructure.Services
{
    internal class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly MailKitConfigurationDto _configurationDto;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _configurationDto = _configuration.GetSection("MailkitOptions").Get<MailKitConfigurationDto>() ?? new();
        }

        public async Task SendEmailAsync(EmailSendDto dto)
        {
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(_configurationDto.Mail);
            email.To.Add(MailboxAddress.Parse(dto.ToEmail));

            email.Subject = dto.Subject;

            var builder = new BodyBuilder();

            if (dto.Attachments != null && dto.Attachments.Count > 0)
            {
                foreach (var attachment in dto.Attachments)
                {
                    if (attachment.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await attachment.CopyToAsync(ms);
                            builder.Attachments.Add(attachment.FileName, ms.ToArray(), ContentType.Parse(attachment.ContentType));
                        }
                    }
                }
            }

            builder.HtmlBody = dto.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(_configurationDto.Host, int.Parse(_configurationDto.Port), SecureSocketOptions.StartTls);
            smtp.Authenticate(_configurationDto.Mail, _configurationDto.Password);

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string username, string confirmationLink)
        {
            var template = await File.ReadAllTextAsync("EmailTemplates/WelcomeEmail.html");
            var body = template
                .Replace("{{username}}", username)
                .Replace("{{confirmationLink}}", confirmationLink);

            var dto = new EmailSendDto
            {
                ToEmail = toEmail,
                Subject = "Welcome to Pomodoro App!",
                Body = body
            };

            await SendEmailAsync(dto);
        }

        public async Task SendNotificationEmailAsync(string toEmail, string title, string message, string? actionLink = null, string? actionButtonText = null)
        {
            var template = await File.ReadAllTextAsync("EmailTemplates/NotificationEmail.html");
            var body = template
                .Replace("{{notificationTitle}}", title)
                .Replace("{{notificationMessage}}", message)
                .Replace("{{actionLink}}", actionLink ?? "")
                .Replace("{{actionButtonText}}", actionButtonText ?? "")
                .Replace("{{settingsLink}}", "https://your-app-url/settings");

            var dto = new EmailSendDto
            {
                ToEmail = toEmail,
                Subject = title,
                Body = body
            };

            await SendEmailAsync(dto);
        }
    }
} 