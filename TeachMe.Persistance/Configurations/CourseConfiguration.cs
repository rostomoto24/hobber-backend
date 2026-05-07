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

        builder.Property(course => course.CreatedAt)
            .IsRequired();
    }
}
