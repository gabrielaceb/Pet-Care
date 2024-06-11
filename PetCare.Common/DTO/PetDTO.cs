using PetCare.Common.Enums;
using PetCare.Common.Enums.Pet;

namespace PetCare.Common.DTO;

public class PetDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Breed { get; set; }
    public required string Color { get; set; }
    public string? Description { get; set; }
    public PetType PetType { get; set; }
    public required DateTime BirthDate { get; set; }
    public string? ImagePath { get; set; }
    public DateTime? LastClinicVisit { get; set; }
    
    public float Weight { get; set; }
    public float Height { get; set; }
    public DateTime CreatedAt { get; set; }
}