using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models.StadnartValues;

namespace PetCare.Infrastructure.ModelsConfiguration;

public class StVaccineConfiguration : IEntityTypeConfiguration<StVaccines>
{
    public void Configure(EntityTypeBuilder<StVaccines> builder)
    {
        builder.ToTable("StVaccines");
        builder.Property(v => v.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(v => v.Name)
            .HasMaxLength(30);
        builder.Property(v => v.Description)
            .HasMaxLength(256);
        builder.Property(v => v.Age)
            .HasMaxLength(4);
    }
}