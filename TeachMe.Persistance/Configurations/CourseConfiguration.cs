using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachMe.Domain.Entities;

namespace TeachMe.Persistance.Configurations;

public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(course => course.Id);

        builder.Property(course => course.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(course => course.Description)
            .HasMaxLength(2_000);

        builder.Property(course => course.Location).HasMaxLength(300);
        builder.Property(course => course.ImageUrl).HasMaxLength(2048);
        builder.Property(course => course.Format).HasConversion<int>().IsRequired();
        builder.Property(course => course.Price).HasPrecision(10, 2);
        builder.Property(course => course.Capacity).IsRequired();

        builder.Property(course => course.CreatedAt)
            .IsRequired();

        builder.HasIndex(course => course.CategoryId);
        builder.HasIndex(course => course.TutorId);

        builder.HasOne(course => course.Tutor)
            .WithMany()
            .HasForeignKey(course => course.TutorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(course => course.Category)
            .WithMany()
            .HasForeignKey(course => course.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
