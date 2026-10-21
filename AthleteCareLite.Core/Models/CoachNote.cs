namespace AthleteCareLite.Core.Models;

public class CoachNote
{
    public Guid NoteId { get; set; } = Guid.NewGuid();
    public Guid AthleteId { get; set; }
    public DateOnly Date { get; set; }
    public string NoteText { get; set; } = string.Empty;

    public Athlete? Athlete { get; set; }
}
