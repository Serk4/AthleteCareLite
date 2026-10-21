using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class TrainingSessionRepository(AppDbContext db) : ITrainingSessionRepository
{
    public Task<List<TrainingSession>> GetByAthleteAsync(Guid athleteId) =>
        db.TrainingSessions
            .Where(t => t.AthleteId == athleteId)
            .OrderByDescending(t => t.Date)
            .ToListAsync();

    public Task<List<TrainingSession>> GetRecentAsync(int days)
    {
        var cutoff = DateOnly.FromDateTime(DateTime.Today.AddDays(-days));
        return db.TrainingSessions
            .Where(t => t.Date >= cutoff)
            .Include(t => t.Athlete)
            .OrderByDescending(t => t.Date)
            .ToListAsync();
    }

    public Task<TrainingSession?> GetByIdAsync(Guid id) =>
        db.TrainingSessions.FindAsync(id).AsTask();

    public async Task AddAsync(TrainingSession session)
    {
        db.TrainingSessions.Add(session);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(TrainingSession session)
    {
        db.TrainingSessions.Update(session);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var session = await db.TrainingSessions.FindAsync(id);
        if (session is not null)
        {
            db.TrainingSessions.Remove(session);
            await db.SaveChangesAsync();
        }
    }
}
