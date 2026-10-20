using AthleteCareLite.Core.Entities;
using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class DailyWellnessCheckInRepository(AthleteCareLiteDbContext dbContext) : IDailyWellnessCheckInRepository
{
    public Task<List<DailyWellnessCheckIn>> GetAllAsync(CancellationToken cancellationToken = default) =>
        dbContext.DailyWellnessCheckIns
            .AsNoTracking()
            .Include(x => x.Athlete)
            .OrderByDescending(x => x.Date)
            .ThenBy(x => x.Id)
            .ToListAsync(cancellationToken);

    public Task<DailyWellnessCheckIn?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.DailyWellnessCheckIns
            .AsNoTracking()
            .Include(x => x.Athlete)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<DailyWellnessCheckIn> AddAsync(DailyWellnessCheckIn entity, CancellationToken cancellationToken = default)
    {
        dbContext.DailyWellnessCheckIns.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(DailyWellnessCheckIn entity, CancellationToken cancellationToken = default)
    {
        dbContext.DailyWellnessCheckIns.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.DailyWellnessCheckIns.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return;
        }

        dbContext.DailyWellnessCheckIns.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<List<DailyWellnessCheckIn>> GetRecentAsync(int count, CancellationToken cancellationToken = default) =>
        dbContext.DailyWellnessCheckIns
            .AsNoTracking()
            .Include(x => x.Athlete)
            .OrderByDescending(x => x.Date)
            .ThenByDescending(x => x.Id)
            .Take(count)
            .ToListAsync(cancellationToken);
}
