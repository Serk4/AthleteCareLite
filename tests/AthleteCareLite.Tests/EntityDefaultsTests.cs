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
        var today = DateTime.UtcNow.Date;

        Assert.Equal(today, new DailyWellnessCheckIn().Date);
        Assert.Equal(today, new TrainingSessionLog().Date);
        Assert.Equal(today, new CoachNote().Date);
    }
}
