using PetCare.Domain.Models.Pet;

namespace PetCare.Domain.Interfaces;

public interface IVaccineRepository
{
    public Task AddVaccine(Vaccine vaccine);
    public Task<Vaccine?> FindById(Guid id);
    public Task<IEnumerable<Vaccine>> FindAll();
    public Task UpdateVaccine(Vaccine vaccine);
    public Task<List<Vaccine>> GetVaccinesByPetId(Guid petId);
    public Task<Vaccine?> GetVaccinesByDateRange(DateTime start, DateTime end);
}