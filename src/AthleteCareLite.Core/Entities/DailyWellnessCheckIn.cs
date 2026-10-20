using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AthleteCareLite.Core.Entities;

public class DailyWellnessCheckIn
{
    public int Id { get; set; }

    [Required]
    public int AthleteId { get; set; }

    [JsonIgnore]
    public AthleteProfile? Athlete { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow.Date;

    [Range(0, 24)]
    public decimal SleepHours { get; set; }

    [Range(1, 10)]
    public int SorenessLevel { get; set; }

    [Required, MaxLength(50)]
    public string Mood { get; set; } = string.Empty;

    [Range(1, 10)]
    public int ReadinessScore { get; set; }
}
