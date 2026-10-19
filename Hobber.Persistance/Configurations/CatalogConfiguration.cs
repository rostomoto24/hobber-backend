using Hobber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hobber.Persistance.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
        builder.Property(c => c.Accent).HasConversion<int>().IsRequired();
        builder.HasIndex(c => c.ParentId);
        builder.HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class UserInterestConfiguration : IEntityTypeConfiguration<UserInterest>
{
    public void Configure(EntityTypeBuilder<UserInterest> builder)
    {
        builder.ToTable("UserInterests");
        builder.HasKey(i => new { i.UserId, i.CategoryId });
        builder.HasOne(i => i.Category).WithMany().HasForeignKey(i => i.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class CourseSessionConfiguration : IEntityTypeConfiguration<CourseSession>
{
    public void Configure(EntityTypeBuilder<CourseSession> builder)
    {
        builder.ToTable("CourseSessions");
        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.StartsAt);
        builder.HasIndex(s => new { s.DayOfWeek, s.StartMinutes });
        builder.HasOne(s => s.Course).WithMany(c => c.Sessions).HasForeignKey(s => s.CourseId).OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments");
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => new { e.CourseId, e.StudentId }).IsUnique();
        builder.HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Restrict);
    }
}
