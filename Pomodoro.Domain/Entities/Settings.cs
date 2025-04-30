using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Domain.Entities
{
    class Settings : BaseAuditableEntity
    {
        public string UserId { get; set; } = null!;
        public string? ChangeEmail { get; set; } 
        public string? ChangePassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }


        public string AccentColor { get; set; } = null!;
        public int FontSize { get; set; }

    }
}
