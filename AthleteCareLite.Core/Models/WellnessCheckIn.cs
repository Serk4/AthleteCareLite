namespace AthleteCareLite.Core.Models;

public class WellnessCheckIn
{
    public Guid CheckInId { get; set; } = Guid.NewGuid();
    public Guid AthleteId { get; set; }
    public DateOnly Date { get; set; }
    public int SleepHours { get; set; }
    public int SorenessLevel { get; set; }
    public int Mood { get; set; }
    public int ReadinessScore { get; set; }

    public Athlete? Athlete { get; set; }
}
