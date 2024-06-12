using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.ModelsConfiguration;

public class PetDetailsConfiguration : IEntityTypeConfiguration<PetDetails>
{
    public void Configure(EntityTypeBuilder<PetDetails> builder)
    {
        builder.ToTable("PetDetails");
        builder.Property(pd => pd.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(pd => pd.Weight)
            .HasMaxLength(32);
        builder.Property(pd => pd.Height)
            .HasMaxLength(32);
        builder.Property(pd => pd.CreatedAt)
            .HasMaxLength(15);
        builder.HasOne(p => p.Pet)
            .WithMany(p => p.PetDetails)
            .HasForeignKey(t => t.PetId);

    }
}