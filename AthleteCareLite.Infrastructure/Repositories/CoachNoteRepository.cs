using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AthleteCareLite.Infrastructure.Repositories;

public class CoachNoteRepository(AppDbContext db) : ICoachNoteRepository
{
    public Task<List<CoachNote>> GetAllAsync() =>
        db.CoachNotes
            .Include(n => n.Athlete)
            .OrderByDescending(n => n.Date)
            .ToListAsync();

    public Task<List<CoachNote>> GetByAthleteAsync(Guid athleteId) =>
        db.CoachNotes
            .Where(n => n.AthleteId == athleteId)
            .OrderByDescending(n => n.Date)
            .ToListAsync();

    public Task<CoachNote?> GetByIdAsync(Guid id) =>
        db.CoachNotes.FindAsync(id).AsTask();

    public async Task AddAsync(CoachNote note)
    {
        db.CoachNotes.Add(note);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(CoachNote note)
    {
        db.CoachNotes.Update(note);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var note = await db.CoachNotes.FindAsync(id);
        if (note is not null)
        {
            db.CoachNotes.Remove(note);
            await db.SaveChangesAsync();
        }
    }
}
