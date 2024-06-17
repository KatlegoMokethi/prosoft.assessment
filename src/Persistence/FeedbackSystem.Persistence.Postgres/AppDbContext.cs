using FeedbackSystem.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Persistence.Postgres;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

    public DbSet<FeedbackEntity> Feedback { get; set; }
}
