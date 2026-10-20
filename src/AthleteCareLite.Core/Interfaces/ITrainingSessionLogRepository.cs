using AthleteCareLite.Core.Entities;

namespace AthleteCareLite.Core.Interfaces;

public interface ITrainingSessionLogRepository : ICrudRepository<TrainingSessionLog>
{
    Task<List<TrainingSessionLog>> GetRecentAsync(int count, CancellationToken cancellationToken = default);
}
