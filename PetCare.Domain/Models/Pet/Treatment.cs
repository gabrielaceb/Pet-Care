using System.ComponentModel.DataAnnotations;

namespace PetCare.Domain.Models.Pet;

public class Treatment
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    
    // References
    public Guid PetId { get; set; }
    public Pet Pet { get; set; }
}