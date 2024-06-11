using System.ComponentModel.DataAnnotations;
using PetCare.Common.Enums.StValues;

namespace PetCare.Domain.Models.StadnartValues;

public class StVaccines
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
    
    public AnimalBreed AnimalBreed { get; set; }
}