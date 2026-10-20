using AthleteCareLite.Core.Entities;
using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class TrainingSessionLogRepository(AthleteCareLiteDbContext dbContext) : ITrainingSessionLogRepository
{
    public Task<List<TrainingSessionLog>> GetAllAsync(CancellationToken cancellationToken = default) =>
        dbContext.TrainingSessionLogs
            .AsNoTracking()
            .Include(x => x.Athlete)
            .OrderByDescending(x => x.Date)
            .ThenBy(x => x.Id)
            .ToListAsync(cancellationToken);

    public Task<TrainingSessionLog?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.TrainingSessionLogs
            .AsNoTracking()
            .Include(x => x.Athlete)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<TrainingSessionLog> AddAsync(TrainingSessionLog entity, CancellationToken cancellationToken = default)
    {
        dbContext.TrainingSessionLogs.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(TrainingSessionLog entity, CancellationToken cancellationToken = default)
    {
        dbContext.TrainingSessionLogs.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.TrainingSessionLogs.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return;
        }

        dbContext.TrainingSessionLogs.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<List<TrainingSessionLog>> GetRecentAsync(int count, CancellationToken cancellationToken = default) =>
        dbContext.TrainingSessionLogs
            .AsNoTracking()
            .Include(x => x.Athlete)
            .OrderByDescending(x => x.Date)
            .ThenByDescending(x => x.Id)
            .Take(count)
            .ToListAsync(cancellationToken);
}
