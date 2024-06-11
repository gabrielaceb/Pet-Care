using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.StadnartValues;

namespace PetCare.Aplication.UseCases;

public class StVaccineUseCase(IStVaccinesRepository _stVaccinesRepository)
{
    
    public async Task AddVaccine(StVaccines vaccine)
    {
        await _stVaccinesRepository.AddVaccine(vaccine);
    }

    public async Task<StVaccines?> FindById(Guid id)
    {
        return await _stVaccinesRepository.FindById(id);
    }

    public async Task<IEnumerable<StVaccines>> FindAll()
    {
        return await _stVaccinesRepository.FindAll();
    }

    public async Task UpdateVaccine(StVaccines vaccine)
    {
        await _stVaccinesRepository.UpdateVaccine(vaccine);
    }

    public async Task<IEnumerable<StVaccines>?> GetVaccinesByDateRange(int ageStart, int ageEnd)
    {
        return await _stVaccinesRepository.GetVaccinesByDateRange(ageStart, ageEnd);
    }

    public async Task<IEnumerable<StVaccines>> GetTopVaccines(int number)
    {
        return await _stVaccinesRepository.GetTopVaccines(number);
    }
}
