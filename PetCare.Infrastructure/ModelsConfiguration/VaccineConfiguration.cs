using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.ModelsConfiguration;

public class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.ToTable("Vaccines");
        builder.Property(v => v.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(v => v.Name)
            .HasMaxLength(30);
        builder.Property(v => v.Description)
            .HasMaxLength(255);
        builder.Property(v => v.Date)
            .HasMaxLength(15);
        builder.HasOne(p => p.Pet)
            .WithMany(v => v.Vaccines)
            .HasForeignKey(v => v.PetId);

    }
}