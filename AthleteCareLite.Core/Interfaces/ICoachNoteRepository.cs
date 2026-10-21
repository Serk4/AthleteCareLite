using AthleteCareLite.Core.Models;

namespace AthleteCareLite.Core.Interfaces;

public interface ICoachNoteRepository
{
    Task<List<CoachNote>> GetAllAsync();
    Task<List<CoachNote>> GetByAthleteAsync(Guid athleteId);
    Task<CoachNote?> GetByIdAsync(Guid id);
    Task AddAsync(CoachNote note);
    Task UpdateAsync(CoachNote note);
    Task DeleteAsync(Guid id);
}
