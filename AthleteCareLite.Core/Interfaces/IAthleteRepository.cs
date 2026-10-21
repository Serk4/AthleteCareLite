using AthleteCareLite.Core.Models;

namespace AthleteCareLite.Core.Interfaces;

public interface IAthleteRepository
{
    Task<List<Athlete>> GetAllAsync();
    Task<Athlete?> GetByIdAsync(Guid id);
    Task AddAsync(Athlete athlete);
    Task UpdateAsync(Athlete athlete);
    Task DeleteAsync(Guid id);
}
