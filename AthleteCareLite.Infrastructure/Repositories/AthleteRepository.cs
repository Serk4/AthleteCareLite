using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class AthleteRepository(AppDbContext db) : IAthleteRepository
{
    public Task<List<Athlete>> GetAllAsync() =>
        db.Athletes.OrderBy(a => a.Name).ToListAsync();

    public Task<Athlete?> GetByIdAsync(Guid id) =>
        db.Athletes
            .Include(a => a.WellnessCheckIns)
            .Include(a => a.TrainingSessions)
            .Include(a => a.CoachNotes)
            .FirstOrDefaultAsync(a => a.AthleteId == id);

    public async Task AddAsync(Athlete athlete)
    {
        db.Athletes.Add(athlete);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Athlete athlete)
    {
        db.Athletes.Update(athlete);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var athlete = await db.Athletes.FindAsync(id);
        if (athlete is not null)
        {
            db.Athletes.Remove(athlete);
            await db.SaveChangesAsync();
        }
    }
}
