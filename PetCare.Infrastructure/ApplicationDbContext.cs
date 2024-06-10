using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetCare.Domain;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public virtual DbSet<Pet> Pets { get; set; }
    public virtual DbSet<PetDetails> PetDetails { get; set; }
    public virtual DbSet<ClinicVisit> ClinicVisits { get; set; }
    public virtual DbSet<Treatment> Treatments { get; set; }
    public virtual DbSet<Vaccine> Vaccines { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}