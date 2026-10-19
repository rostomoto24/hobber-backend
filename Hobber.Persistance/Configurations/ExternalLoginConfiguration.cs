using Hobber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hobber.Persistance.Configurations;

public sealed class ExternalLoginConfiguration : IEntityTypeConfiguration<ExternalLogin>
{
    public void Configure(EntityTypeBuilder<ExternalLogin> builder)
    {
        builder.ToTable("ExternalLogins");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Provider).HasMaxLength(32).IsRequired();
        builder.Property(l => l.ProviderSubjectId).HasMaxLength(256).IsRequired();
        builder.HasIndex(l => new { l.Provider, l.ProviderSubjectId }).IsUnique();
        builder.HasOne(l => l.User)
            .WithMany(u => u.ExternalLogins)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
