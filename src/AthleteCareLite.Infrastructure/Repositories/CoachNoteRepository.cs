using AthleteCareLite.Core.Entities;
using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class CoachNoteRepository(AthleteCareLiteDbContext dbContext) : ICoachNoteRepository
{
    public Task<List<CoachNote>> GetAllAsync(CancellationToken cancellationToken = default) =>
        dbContext.CoachNotes
            .AsNoTracking()
            .Include(x => x.Athlete)
            .OrderByDescending(x => x.Date)
            .ThenBy(x => x.Id)
            .ToListAsync(cancellationToken);

    public Task<CoachNote?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.CoachNotes
            .AsNoTracking()
            .Include(x => x.Athlete)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<CoachNote> AddAsync(CoachNote entity, CancellationToken cancellationToken = default)
    {
        dbContext.CoachNotes.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(CoachNote entity, CancellationToken cancellationToken = default)
    {
        dbContext.CoachNotes.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.CoachNotes.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return;
        }

        dbContext.CoachNotes.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
