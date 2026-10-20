using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AthleteCareLite.Core.Entities;

public class TrainingSessionLog
{
    public int Id { get; set; }

    [Required]
    public int AthleteId { get; set; }

    [JsonIgnore]
    public AthleteProfile? Athlete { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow.Date;

    [Required, MaxLength(100)]
    public string Activity { get; set; } = string.Empty;

    [Range(1, 1440)]
    public int DurationMinutes { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
}
