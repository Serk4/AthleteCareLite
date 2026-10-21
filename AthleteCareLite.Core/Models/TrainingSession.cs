namespace AthleteCareLite.Core.Models;

public class TrainingSession
{
    public Guid SessionId { get; set; } = Guid.NewGuid();
    public Guid AthleteId { get; set; }
    public DateOnly Date { get; set; }
    public string Activity { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public string Notes { get; set; } = string.Empty;

    public Athlete? Athlete { get; set; }
}
