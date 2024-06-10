using System.ComponentModel.DataAnnotations;
using PetCare.Common.Enums;

namespace PetCare.Domain.Models.Pet;

public class Pet
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Breed { get; set; }
    public required string Color { get; set; }
    public string? Description { get; set; }
    public PetType PetType { get; set; }
    public required DateTime BirthDate { get; set; }
    public string? ImagePath { get; set; }
    
    public DateTime LastClinicVisit { get; set; }
    
    // References
    public ICollection<Vaccine> Vaccines { get; set; }
    public ICollection<ClinicVisit> ClinicVisits { get; set; }
    public ICollection<Treatment> Treatments { get; set; }
    public ICollection<PetDetails> PetDetails { get; set; }
    
    
    
    
    
}