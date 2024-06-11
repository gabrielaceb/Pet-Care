using PetCare.Domain.Models.Pet;

namespace PetCare.Domain.Interfaces;

public interface IPetRepository
{
    public Task AddPet(Pet pet);
    public Task<Pet?> FindById(Guid id);
    public Task<IEnumerable<Pet>> FindAll();
    public Task UpdatePet(Pet pet);
    
}