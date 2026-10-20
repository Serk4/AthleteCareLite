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

api.MapPost("/athletes", async (AthleteProfile athlete, IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
    Results.Created($"/api/athletes/{athlete.Id}", await repository.AddAsync(athlete, cancellationToken)));

api.MapPut("/athletes/{id:int}", async (int id, AthleteProfile athlete, IAthleteProfileRepository repository, CancellationToken cancellationToken) =>
{
    if (id != athlete.Id)
    {
        return Results.BadRequest("Route id and payload id must match.");
    }

    await repository.UpdateAsync(athlete, cancellationToken);
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

api.MapPost("/wellness-checkins", async (DailyWellnessCheckIn checkIn, IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
    Results.Created($"/api/wellness-checkins/{checkIn.Id}", await repository.AddAsync(checkIn, cancellationToken)));

api.MapPut("/wellness-checkins/{id:int}", async (int id, DailyWellnessCheckIn checkIn, IDailyWellnessCheckInRepository repository, CancellationToken cancellationToken) =>
{
    if (id != checkIn.Id)
    {
        return Results.BadRequest("Route id and payload id must match.");
    }

    await repository.UpdateAsync(checkIn, cancellationToken);
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

api.MapPost("/training-logs", async (TrainingSessionLog log, ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
    Results.Created($"/api/training-logs/{log.Id}", await repository.AddAsync(log, cancellationToken)));

api.MapPut("/training-logs/{id:int}", async (int id, TrainingSessionLog log, ITrainingSessionLogRepository repository, CancellationToken cancellationToken) =>
{
    if (id != log.Id)
    {
        return Results.BadRequest("Route id and payload id must match.");
    }

    await repository.UpdateAsync(log, cancellationToken);
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

api.MapPost("/coach-notes", async (CoachNote note, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
    Results.Created($"/api/coach-notes/{note.Id}", await repository.AddAsync(note, cancellationToken)));

api.MapPut("/coach-notes/{id:int}", async (int id, CoachNote note, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
{
    if (id != note.Id)
    {
        return Results.BadRequest("Route id and payload id must match.");
    }

    await repository.UpdateAsync(note, cancellationToken);
    return Results.NoContent();
});

api.MapDelete("/coach-notes/{id:int}", async (int id, ICoachNoteRepository repository, CancellationToken cancellationToken) =>
{
    await repository.DeleteAsync(id, cancellationToken);
    return Results.NoContent();
});

app.Run();
