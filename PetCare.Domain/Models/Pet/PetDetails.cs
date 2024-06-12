using System.ComponentModel.DataAnnotations;

namespace PetCare.Domain.Models.Pet;

public class PetDetails
{
    [Key]
    public Guid Id { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public DateTime? CreatedAt { get; set; }
    
    // References
    public Guid PetId { get; set; }
    public Pet Pet { get; set; }
    
}