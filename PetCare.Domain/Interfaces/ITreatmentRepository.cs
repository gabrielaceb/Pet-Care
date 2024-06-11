using PetCare.Domain.Models.Pet;

namespace PetCare.Domain.Interfaces;

public interface ITreatmentRepository
{
    public Task AddTreatment(Treatment treatment);
    public Task<Treatment?> FindById(Guid id);
    public Task<IEnumerable<Treatment>> FindAll();
    public Task UpdateTreatment(Treatment treatment);
    public Task<List<Treatment>> GetTreatmentsByPetId(Guid petId);
    public Task<Treatment?> GetTreatmentsByDateRange(DateTime start, DateTime end);
    
}