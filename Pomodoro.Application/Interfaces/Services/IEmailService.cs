using Pomodoro.Application.DTOs.Email;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailSendDto dto);
        Task SendWelcomeEmailAsync(string toEmail, string username, string confirmationLink);
        Task SendNotificationEmailAsync(string toEmail, string title, string message, string? actionLink = null, string? actionButtonText = null);
    }
} 