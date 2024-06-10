using System.ComponentModel.DataAnnotations;
using PetCare.Common.Enums;

namespace PetCare.Domain.Models.Pet;

public class ClinicVisit
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string? Diagnosis { get; set; }
    public string? Prescription { get; set; }
    
    public VisitReason VisitReason { get; set; }
    
    // References
    public Guid PetId { get; set; }
    public Pet Pet { get; set; }
}