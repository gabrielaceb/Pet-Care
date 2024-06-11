using PetCare.Domain.Models.StadnartValues;

namespace PetCare.Domain.Interfaces;

public interface IStVaccinesRepository
{
    public Task AddVaccine(StVaccines vaccine);
    public Task<StVaccines?> FindById(Guid id);
    public Task<IEnumerable<StVaccines>> FindAll();
    public Task UpdateVaccine(StVaccines vaccine);
    public Task<IEnumerable<StVaccines>?> GetVaccinesByDateRange( int ageStart, int ageEnd);
    public Task<IEnumerable<StVaccines>> GetTopVaccines(int number);
    
}