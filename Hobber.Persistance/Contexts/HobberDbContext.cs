using Hobber.Application.Abstractions;
using Hobber.Domain.Entities;
using Hobber.Persistance.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Hobber.Persistance.Contexts;

public sealed class HobberDbContext(DbContextOptions<HobberDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<ExternalLogin> ExternalLogins => Set<ExternalLogin>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<UserInterest> UserInterests => Set<UserInterest>();

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<CourseSession> CourseSessions => Set<CourseSession>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HobberDbContext).Assembly);

        // Reference + demo rows ship inside the migrations (see SeedData).
        SeedData.Apply(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}
