namespace Pomodoro.Application.DTOs.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
} 