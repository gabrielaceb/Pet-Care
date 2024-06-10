using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.ModelsConfiguration;

public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.ToTable("Treatments");
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(t => t.Name)
            .HasMaxLength(25);
        builder.Property(t => t.Description)
            .HasMaxLength(255);
        builder.Property(t => t.StartDate)
            .HasMaxLength(15);
        builder.Property(t => t.EndDate)
            .HasMaxLength(15);
        builder.HasOne(p => p.Pet)
            .WithMany(t => t.Treatments)
            .HasForeignKey(t => t.PetId);
    }
}