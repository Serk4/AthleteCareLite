namespace AthleteCareLite.Core.Models;

public class Athlete
{
    public Guid AthleteId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public int GraduationYear { get; set; }
    public string PrimarySport { get; set; } = string.Empty;

    public ICollection<WellnessCheckIn> WellnessCheckIns { get; set; } = [];
    public ICollection<TrainingSession> TrainingSessions { get; set; } = [];
    public ICollection<CoachNote> CoachNotes { get; set; } = [];
}
