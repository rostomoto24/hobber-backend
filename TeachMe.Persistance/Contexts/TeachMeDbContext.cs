using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Domain.Entities;

namespace TeachMe.Persistance.Contexts;

public sealed class TeachMeDbContext(DbContextOptions<TeachMeDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<User> Users => Set<User>();

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeachMeDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
