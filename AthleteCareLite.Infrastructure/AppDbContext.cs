using AthleteCareLite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Athlete> Athletes => Set<Athlete>();
    public DbSet<WellnessCheckIn> WellnessCheckIns => Set<WellnessCheckIn>();
    public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();
    public DbSet<CoachNote> CoachNotes => Set<CoachNote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Athlete>().HasKey(a => a.AthleteId);
        modelBuilder.Entity<WellnessCheckIn>().HasKey(w => w.CheckInId);
        modelBuilder.Entity<TrainingSession>().HasKey(t => t.SessionId);
        modelBuilder.Entity<CoachNote>().HasKey(n => n.NoteId);

        modelBuilder.Entity<Athlete>()
            .HasMany(a => a.WellnessCheckIns)
            .WithOne(w => w.Athlete)
            .HasForeignKey(w => w.AthleteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Athlete>()
            .HasMany(a => a.TrainingSessions)
            .WithOne(t => t.Athlete)
            .HasForeignKey(t => t.AthleteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Athlete>()
            .HasMany(a => a.CoachNotes)
            .WithOne(n => n.Athlete)
            .HasForeignKey(n => n.AthleteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
