using Microsoft.EntityFrameworkCore;
using Ordering.Model.Entities;

namespace Ordering.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Review> Reviews { get; set; }
}