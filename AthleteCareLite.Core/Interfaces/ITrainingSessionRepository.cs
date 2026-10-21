using AthleteCareLite.Core.Models;

namespace AthleteCareLite.Core.Interfaces;

public interface ITrainingSessionRepository
{
    Task<List<TrainingSession>> GetByAthleteAsync(Guid athleteId);
    Task<List<TrainingSession>> GetRecentAsync(int days);
    Task<TrainingSession?> GetByIdAsync(Guid id);
    Task AddAsync(TrainingSession session);
    Task UpdateAsync(TrainingSession session);
    Task DeleteAsync(Guid id);
}
