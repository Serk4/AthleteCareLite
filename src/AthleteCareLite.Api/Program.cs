using AthleteCareLite.Core.Entities;
using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var api = app.MapGroup("/api");

api.MapGet("/athletes", async (IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
    Results.Ok(await repository.GetAllAsync(cancellationToken)));

api.MapGet("/athletes/{id:int}", async (int id, IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
{
    var athlete = await repository.GetByIdAsync(id, cancellationToken);
    return athlete is null ? Results.NotFound() : Results.Ok(athlete);
});

api.MapPost("/athletes", async (AthleteProfileUpsertRequest request, IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
{
    var savedAthlete = await repository.AddAsync(new AthleteProfile
    {
        Name = request.Name,
        School = request.School,
        GraduationYear = request.GraduationYear,
        PrimarySport = request.PrimarySport
    }, cancellationToken);
    return Results.Created($"/api/athletes/{savedAthlete.Id}", savedAthlete);
});

api.MapPut("/athletes/{id:int}", async (int id, AthleteProfileUpsertRequest request, IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
{
    var existing = await repository.GetByIdAsync(id, cancellationToken);
    if (existing is null)
    {
        return Results.NotFound();
    }

    await repository.UpdateAsync(new AthleteProfile
    {
        Id = id,
        Name = request.Name,
        School = request.School,
        GraduationYear = request.GraduationYear,
        PrimarySport = request.PrimarySport
    }, cancellationToken);

    return Results.NoContent();
});

api.MapDelete("/athletes/{id:int}", async (int id, IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
{
    await repository.DeleteAsync(id, cancellationToken);
    return Results.NoContent();
});

api.MapGet("/wellness-checkins", async (IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
    Results.Ok(await repository.GetAllAsync(cancellationToken)));

api.MapGet("/wellness-checkins/{id:int}", async (int id, IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
{
    var checkIn = await repository.GetByIdAsync(id, cancellationToken);
    return checkIn is null ? Results.NotFound() : Results.Ok(checkIn);
});

api.MapPost("/wellness-checkins", async (DailyWellnessCheckInUpsertRequest request, IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
{
    var savedCheckIn = await repository.AddAsync(new DailyWellnessCheckIn
    {
        AthleteId = request.AthleteId,
        Date = request.Date,
        SleepHours = request.SleepHours,
        SorenessLevel = request.SorenessLevel,
        Mood = request.Mood,
        ReadinessScore = request.ReadinessScore
    }, cancellationToken);

    return Results.Created($"/api/wellness-checkins/{savedCheckIn.Id}", savedCheckIn);
});

api.MapPut("/wellness-checkins/{id:int}", async (int id, DailyWellnessCheckInUpsertRequest request, IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
{
    var existing = await repository.GetByIdAsync(id, cancellationToken);
    if (existing is null)
    {
        return Results.NotFound();
    }

    await repository.UpdateAsync(new DailyWellnessCheckIn
    {
        Id = id,
        AthleteId = request.AthleteId,
        Date = request.Date,
        SleepHours = request.SleepHours,
        SorenessLevel = request.SorenessLevel,
        Mood = request.Mood,
        ReadinessScore = request.ReadinessScore
    }, cancellationToken);

    return Results.NoContent();
});

api.MapDelete("/wellness-checkins/{id:int}", async (int id, IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
{
    await repository.DeleteAsync(id, cancellationToken);
    return Results.NoContent();
});

api.MapGet("/training-logs", async (ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
    Results.Ok(await repository.GetAllAsync(cancellationToken)));

api.MapGet("/training-logs/{id:int}", async (int id, ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
{
    var log = await repository.GetByIdAsync(id, cancellationToken);
    return log is null ? Results.NotFound() : Results.Ok(log);
});

api.MapPost("/training-logs", async (TrainingSessionLogUpsertRequest request, ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
{
    var savedLog = await repository.AddAsync(new TrainingSessionLog
    {
        AthleteId = request.AthleteId,
        Date = request.Date,
        Activity = request.Activity,
        DurationMinutes = request.DurationMinutes,
        Notes = request.Notes
    }, cancellationToken);

    return Results.Created($"/api/training-logs/{savedLog.Id}", savedLog);
});

api.MapPut("/training-logs/{id:int}", async (int id, TrainingSessionLogUpsertRequest request, ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
{
    var existing = await repository.GetByIdAsync(id, cancellationToken);
    if (existing is null)
    {
        return Results.NotFound();
    }

    await repository.UpdateAsync(new TrainingSessionLog
    {
        Id = id,
        AthleteId = request.AthleteId,
        Date = request.Date,
        Activity = request.Activity,
        DurationMinutes = request.DurationMinutes,
        Notes = request.Notes
    }, cancellationToken);

    return Results.NoContent();
});

api.MapDelete("/training-logs/{id:int}", async (int id, ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
{
    await repository.DeleteAsync(id, cancellationToken);
    return Results.NoContent();
});

api.MapGet("/coach-notes", async (ICoachNoteRepository repository, CancellationToken cancellationToken) =>
    Results.Ok(await repository.GetAllAsync(cancellationToken)));

api.MapGet("/coach-notes/{id:int}", async (int id, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
{
    var note = await repository.GetByIdAsync(id, cancellationToken);
    return note is null ? Results.NotFound() : Results.Ok(note);
});

api.MapPost("/coach-notes", async (CoachNoteUpsertRequest request, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
{
    var savedNote = await repository.AddAsync(new CoachNote
    {
        AthleteId = request.AthleteId,
        Date = request.Date,
        NoteText = request.NoteText
    }, cancellationToken);

    return Results.Created($"/api/coach-notes/{savedNote.Id}", savedNote);
});

api.MapPut("/coach-notes/{id:int}", async (int id, CoachNoteUpsertRequest request, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
{
    var existing = await repository.GetByIdAsync(id, cancellationToken);
    if (existing is null)
    {
        return Results.NotFound();
    }

    await repository.UpdateAsync(new CoachNote
    {
        Id = id,
        AthleteId = request.AthleteId,
        Date = request.Date,
        NoteText = request.NoteText
    }, cancellationToken);

    return Results.NoContent();
});

api.MapDelete("/coach-notes/{id:int}", async (int id, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
{
    await repository.DeleteAsync(id, cancellationToken);
    return Results.NoContent();
});

app.Run();

public sealed record AthleteProfileUpsertRequest(string Name, string School, int GraduationYear, string PrimarySport);
public sealed record DailyWellnessCheckInUpsertRequest(int AthleteId, DateTime Date, decimal SleepHours, int SorenessLevel, string Mood, int ReadinessScore);
public sealed record TrainingSessionLogUpsertRequest(int AthleteId, DateTime Date, string Activity, int DurationMinutes, string? Notes);
public sealed record CoachNoteUpsertRequest(int AthleteId, DateTime Date, string NoteText);
