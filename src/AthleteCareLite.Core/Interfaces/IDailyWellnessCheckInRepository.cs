using AthleteCareLite.Core.Entities;

namespace AthleteCareLite.Core.Interfaces;

public interface IDailyWellnessCheckInRepository : ICrudRepository<DailyWellnessCheckIn>
{
    Task<List<DailyWellnessCheckIn>> GetRecentAsync(int count, CancellationToken cancellationToken = default);
}
