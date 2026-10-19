using Microsoft.EntityFrameworkCore;
using Hobber.Domain.Entities;

namespace Hobber.Application.Abstractions;

/// <summary>The persistence surface handlers depend on; implemented by Hobber.Persistance.</summary>
public interface IAppDbContext
{
    DbSet<User> Users { get; }

    DbSet<RefreshToken> RefreshTokens { get; }

    DbSet<PasswordResetToken> PasswordResetTokens { get; }

    DbSet<Category> Categories { get; }

    DbSet<UserInterest> UserInterests { get; }

    DbSet<Course> Courses { get; }

    DbSet<CourseSession> CourseSessions { get; }

    DbSet<Enrollment> Enrollments { get; }

    DbSet<Notification> Notifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
