using AthleteCareLite.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Data;

public class AthleteCareLiteDbContext(DbContextOptions<AthleteCareLiteDbContext> options) : DbContext(options)
{
    public DbSet<AthleteProfile> AthleteProfiles => Set<AthleteProfile>();
    public DbSet<DailyWellnessCheckIn> DailyWellnessCheckIns => Set<DailyWellnessCheckIn>();
    public DbSet<TrainingSessionLog> TrainingSessionLogs => Set<TrainingSessionLog>();
    public DbSet<CoachNote> CoachNotes => Set<CoachNote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AthleteProfile>(entity =>
        {
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.School).HasMaxLength(100);
            entity.Property(x => x.PrimarySport).HasMaxLength(100);
        });

        modelBuilder.Entity<DailyWellnessCheckIn>(entity =>
        {
            entity.Property(x => x.Mood).HasMaxLength(50);
            entity.Property(x => x.SleepHours).HasPrecision(5, 2);
            entity.HasOne(x => x.Athlete)
                .WithMany(x => x.DailyWellnessCheckIns)
                .HasForeignKey(x => x.AthleteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TrainingSessionLog>(entity =>
        {
            entity.Property(x => x.Activity).HasMaxLength(100);
            entity.Property(x => x.Notes).HasMaxLength(500);
            entity.HasOne(x => x.Athlete)
                .WithMany(x => x.TrainingSessionLogs)
                .HasForeignKey(x => x.AthleteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CoachNote>(entity =>
        {
            entity.Property(x => x.NoteText).HasMaxLength(1000);
            entity.HasOne(x => x.Athlete)
                .WithMany(x => x.CoachNotes)
                .HasForeignKey(x => x.AthleteId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
