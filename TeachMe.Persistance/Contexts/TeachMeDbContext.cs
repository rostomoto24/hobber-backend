using Microsoft.EntityFrameworkCore;
using TeachMe.Domain.Entities;

namespace TeachMe.Persistance.Contexts;

public sealed class TeachMeDbContext(DbContextOptions<TeachMeDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeachMeDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
