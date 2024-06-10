using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PetCare.Domain.Models.Pet;

public class Vaccine
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    
    // References
    public Guid PetId { get; set; }
    [JsonIgnore]
    public Pet Pet { get; set; }
}