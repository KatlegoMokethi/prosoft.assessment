using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FeedbackSystem.Persistence.Postgres;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=FeedbackSystemDb;Username=prosoftAdmin;Password=admin;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
