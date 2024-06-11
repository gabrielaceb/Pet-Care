using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Aplication.UseCases;

public class PetUseCase(IPetRepository petRepository)
{
    public async Task AddPet(Pet pet)
    {
        await petRepository.AddPet(pet);
    }
    
    public async Task UpdatePet(Pet pet)
    {
        await petRepository.UpdatePet(pet);
    }
    
    public async Task<Pet?> FindPetById(Guid id)
    {
        return await petRepository.FindById(id);
    }
    
    public async Task<IEnumerable<Pet>> FindAllPets()
    {
        return await petRepository.FindAll();
    }
    
}