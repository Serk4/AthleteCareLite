using AthleteCareLite.Core.Models;

namespace AthleteCareLite.Core.Interfaces;

public interface IWellnessCheckInRepository
{
    Task<List<WellnessCheckIn>> GetByAthleteAsync(Guid athleteId);
    Task<List<WellnessCheckIn>> GetRecentAsync(int days);
    Task<WellnessCheckIn?> GetByIdAsync(Guid id);
    Task AddAsync(WellnessCheckIn checkIn);
    Task UpdateAsync(WellnessCheckIn checkIn);
    Task DeleteAsync(Guid id);
}
