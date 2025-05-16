using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Configurations
{
    internal class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.Property(x => x.AccentColor)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(x => x.FontSize)
                .IsRequired();

            builder.Property(x => x.WorkDuration)
                .IsRequired();

            builder.Property(x => x.ShortBreakDuration)
                .IsRequired();

            builder.Property(x => x.LongBreakDuration)
                .IsRequired();

            builder.Property(x => x.LongBreakInterval)
                .IsRequired();

            builder.Property(x => x.Theme)
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("light");

            builder.HasOne(x => x.User)
                .WithOne(x => x.Settings)
                .HasForeignKey<UserSettings>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 