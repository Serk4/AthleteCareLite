using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AthleteCareLite.Core.Entities;

public class CoachNote
{
    public int Id { get; set; }

    [Required]
    public int AthleteId { get; set; }

    [JsonIgnore]
    public AthleteProfile? Athlete { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow.Date;

    [Required, MaxLength(1000)]
    public string NoteText { get; set; } = string.Empty;
}
