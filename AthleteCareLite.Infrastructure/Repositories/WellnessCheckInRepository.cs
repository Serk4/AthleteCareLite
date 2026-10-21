using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class WellnessCheckInRepository(AppDbContext db) : IWellnessCheckInRepository
{
    public Task<List<WellnessCheckIn>> GetByAthleteAsync(Guid athleteId) =>
        db.WellnessCheckIns
            .Where(w => w.AthleteId == athleteId)
            .OrderByDescending(w => w.Date)
            .ToListAsync();

    public Task<List<WellnessCheckIn>> GetRecentAsync(int days)
    {
        var cutoff = DateOnly.FromDateTime(DateTime.Today.AddDays(-days));
        return db.WellnessCheckIns
            .Where(w => w.Date >= cutoff)
            .Include(w => w.Athlete)
            .OrderByDescending(w => w.Date)
            .ToListAsync();
    }

    public Task<WellnessCheckIn?> GetByIdAsync(Guid id) =>
        db.WellnessCheckIns.FindAsync(id).AsTask();

    public async Task AddAsync(WellnessCheckIn checkIn)
    {
        db.WellnessCheckIns.Add(checkIn);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(WellnessCheckIn checkIn)
    {
        db.WellnessCheckIns.Update(checkIn);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var checkIn = await db.WellnessCheckIns.FindAsync(id);
        if (checkIn is not null)
        {
            db.WellnessCheckIns.Remove(checkIn);
            await db.SaveChangesAsync();
        }
    }
}
