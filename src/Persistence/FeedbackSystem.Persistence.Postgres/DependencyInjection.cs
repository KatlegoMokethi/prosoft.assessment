using FeedbackSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackSystem.Persistence.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddSingleton<IFeedbackRepository, FeedbackRepository>();

        var contectFactory = services.BuildServiceProvider().GetRequiredService<IDbContextFactory<AppDbContext>>();
        using var context = contectFactory.CreateDbContext();
        context.Database.Migrate();

        return services;
    }
}
