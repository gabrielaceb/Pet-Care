using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.ModelsConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets");
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .HasMaxLength(15);
        builder.Property(p => p.BirthDate)
            .HasMaxLength(15);
        builder.Property(p => p.Breed)
            .HasMaxLength(35);
        builder.Property(p => p.Color)
            .HasMaxLength(15);
        builder.Property(p => p.LastClinicVisit)
            .HasMaxLength(15);
        builder.Property(p => p.Description)
            .HasMaxLength(15);
        builder.Property(p => p.LastClinicVisit)
            .HasMaxLength(15);
        
    }
}