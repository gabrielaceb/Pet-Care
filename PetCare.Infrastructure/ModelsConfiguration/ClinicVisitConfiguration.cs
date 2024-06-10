using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.ModelsConfiguration;

public class ClinicVisitConfiguration : IEntityTypeConfiguration<ClinicVisit>
{
    public void Configure(EntityTypeBuilder<ClinicVisit> builder)
    {
        builder.ToTable("ClinicVisits");
        builder.Property(cv => cv.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(cv => cv.Date)
            .HasMaxLength(15);
        builder.Property(cv => cv.Description)
            .HasMaxLength(255);
        builder.Property(cv => cv.Diagnosis)
            .HasMaxLength(255);
        builder.Property(cv => cv.Prescription)
            .HasMaxLength(255);
        
        builder.HasOne(cv => cv.Pet)
            .WithMany(p => p.ClinicVisits)
            .HasForeignKey(cv => cv.PetId);
    }

}