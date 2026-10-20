using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AthleteCareLite.Core.Entities;

public class AthleteProfile
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string School { get; set; } = string.Empty;

    [Range(1900, 3000)]
    public int GraduationYear { get; set; }

    [Required, MaxLength(100)]
    public string PrimarySport { get; set; } = string.Empty;

    [JsonIgnore]
    public List<DailyWellnessCheckIn> DailyWellnessCheckIns { get; set; } = [];

    [JsonIgnore]
    public List<TrainingSessionLog> TrainingSessionLogs { get; set; } = [];

    [JsonIgnore]
    public List<CoachNote> CoachNotes { get; set; } = [];
}
