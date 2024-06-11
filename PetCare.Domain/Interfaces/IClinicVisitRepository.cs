using PetCare.Domain.Models.Pet;

namespace PetCare.Domain.Interfaces;

public interface IClinicVisitRepository
{
    public Task AddVisit(ClinicVisit visit);

    public Task<ClinicVisit?> FindById(Guid id);

    public Task<IEnumerable<ClinicVisit>> FindAll();

    public Task UpdateVisit(ClinicVisit visit);

    public Task<List<ClinicVisit>> GetVisitsByPetId(Guid petId);

    public Task<ClinicVisit?> GetVisitsByDateRange(Guid petId, DateTime start, DateTime end);

    public Task<IEnumerable<ClinicVisit>> GetTopVisits(Guid petId, int number);
}