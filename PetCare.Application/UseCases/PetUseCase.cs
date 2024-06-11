using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Aplication.UseCases;


public class PetUseCase(IPetRepository petRepository,
    IPetDetailsRepository petDetailsRepository,
    IVaccineRepository vaccineRepository,
    ITreatmentRepository treatmentRepository,
    IClinicVisitRepository clinicVisitRepository)
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
    
    public async Task<IEnumerable<PetDetails>> FindAllPetDetails(Guid petId)
    {
        return await petDetailsRepository.GetPetDetailsByPetId(petId);
    }
    
    public async Task AddPetDetails(PetDetails petDetails)
    {
        await petDetailsRepository.AddPetDetails(petDetails);
    }
    
    public async Task UpdatePetDetails(PetDetails petDetails)
    {
        await petDetailsRepository.UpdatePetDetails(petDetails);
    }
    
    public async Task<IEnumerable<Vaccine>> FindAllVaccines(Guid petId)
    {
        return await vaccineRepository.GetVaccinesByPetId(petId);
    }
    
    public async Task<IEnumerable<Vaccine>?>? FindVaccinesByDateRange(Guid petId, DateTime start, DateTime end)
    {
        return await vaccineRepository.GetVaccinesByDateRange(petId, start, end);
    }
    
    public async Task<IEnumerable<Vaccine>> GetTopVaccines(Guid petId, int number)
    {
        return await vaccineRepository.GetTopVaccines(petId, number);
    }
    
    public async Task AddVaccine(Vaccine vaccine)
    {
        await vaccineRepository.AddVaccine(vaccine);
    }
    
    public async Task<IEnumerable<ClinicVisit>> GetTopClinicVisits(Guid petId, int number)
    {
        return await clinicVisitRepository.GetTopVisits(petId, number);
    }
}