using AthleteCareLite.Core.Entities;

namespace AthleteCareLite.Tests;

public class EntityDefaultsTests
{
    [Fact]
    public void AthleteProfile_DefaultStrings_AreNonNull()
    {
        var athlete = new AthleteProfile();

        Assert.Equal(string.Empty, athlete.Name);
        Assert.Equal(string.Empty, athlete.School);
        Assert.Equal(string.Empty, athlete.PrimarySport);
    }

    [Fact]
    public void WellnessAndTrainingEntities_DefaultDates_AreUtcDate()
    {
        var beforeWellness = DateTime.UtcNow.Date;
        var wellnessCheckIn = new DailyWellnessCheckIn();
        var afterWellness = DateTime.UtcNow.Date;
        Assert.InRange(wellnessCheckIn.Date, beforeWellness, afterWellness);

        var beforeTraining = DateTime.UtcNow.Date;
        var trainingSessionLog = new TrainingSessionLog();
        var afterTraining = DateTime.UtcNow.Date;
        Assert.InRange(trainingSessionLog.Date, beforeTraining, afterTraining);

        var beforeCoachNote = DateTime.UtcNow.Date;
        var coachNote = new CoachNote();
        var afterCoachNote = DateTime.UtcNow.Date;
        Assert.InRange(coachNote.Date, beforeCoachNote, afterCoachNote);
    }
}
