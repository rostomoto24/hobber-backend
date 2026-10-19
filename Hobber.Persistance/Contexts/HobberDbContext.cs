using Hobber.Application.Abstractions;
using Hobber.Domain.Entities;
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

        base.OnModelCreating(modelBuilder);
    }
}
