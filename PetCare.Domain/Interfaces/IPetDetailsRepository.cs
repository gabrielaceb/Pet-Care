using PetCare.Domain.Models.Pet;

namespace PetCare.Domain.Interfaces;

public interface IPetDetailsRepository
{
    public Task AddPetDetails(PetDetails petDetails);
    public Task<PetDetails?> FindById(Guid id);
    public Task<IEnumerable<PetDetails>> FindAll();
    public Task UpdatePetDetails(PetDetails petDetails);
    public Task<List<PetDetails>> GetPetDetailsByPetId(Guid petId);
    public Task<PetDetails?> GetPetDetailsByDateRange(DateTime start, DateTime end);
    
}