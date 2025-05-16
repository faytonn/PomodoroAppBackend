using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Configurations
{
    internal class PomodoroTaskConfiguration : IEntityTypeConfiguration<PomodoroTask>
    {
        public void Configure(EntityTypeBuilder<PomodoroTask> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            //builder.Property(x => x.)
            //    .HasMaxLength(500);

            builder.Property(x => x.Progress)
                .IsRequired();

            builder.Property(x => x.Priority)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.PomodoroTasks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 