using AthleteCareLite.Core.Interfaces;
using AthleteCareLite.Infrastructure.Data;
using AthleteCareLite.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AthleteCareLite.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? "Server=localhost;Database=AthleteCareLiteDb;Trusted_Connection=True;TrustServerCertificate=True;";

        services.AddDbContext<AthleteCareLiteDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IAthleteProfileRepository, AthleteProfileRepository>();
        services.AddScoped<IDailyWellnessCheckInRepository, DailyWellnessCheckInRepository>();
        services.AddScoped<ITrainingSessionLogRepository, TrainingSessionLogRepository>();
        services.AddScoped<ICoachNoteRepository, CoachNoteRepository>();

        return services;
    }
}
