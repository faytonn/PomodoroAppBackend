using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Application.DTOs.Email
{
    public class EmailSendDto
    {
        [Required(ErrorMessage = "Recipient email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string ToEmail { get; set; } = null!;

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; } = null!;

        public List<IFormFile> Attachments { get; set; } = new();
        
    }
} 