using AthleteCareLite.Core.Entities;
using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class AthleteProfileRepository(AthleteCareLiteDbContext dbContext) : IAthleteProfileRepository
{
    public Task<List<AthleteProfile>> GetAllAsync(CancellationToken cancellationToken = default) =>
        dbContext.AthleteProfiles
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

    public Task<AthleteProfile?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.AthleteProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<AthleteProfile> AddAsync(AthleteProfile entity, CancellationToken cancellationToken = default)
    {
        dbContext.AthleteProfiles.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(AthleteProfile entity, CancellationToken cancellationToken = default)
    {
        dbContext.AthleteProfiles.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.AthleteProfiles.FindAsync([id], cancellationToken);
        if (entity is null)
        {
            return;
        }

        dbContext.AthleteProfiles.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
