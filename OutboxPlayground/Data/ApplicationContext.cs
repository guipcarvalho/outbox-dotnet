using Microsoft.EntityFrameworkCore;
using Ordering.Model.Entities;

namespace Ordering.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Outbox> Outbox { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new OutboxInterceptor());
    }
}