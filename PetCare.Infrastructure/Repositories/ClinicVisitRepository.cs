using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.Repositories;

public class ClinicVisitRepository(ApplicationDbContext context) : IClinicVisitRepository
{

   

   

    public async Task AddVisit(ClinicVisit visit)
    {
        context.ClinicVisits.Add(visit);
        await context.SaveChangesAsync();
    }

    public async Task<ClinicVisit?> FindById(Guid id)
    {
        return (await context.ClinicVisits
            .Include(c => c.Pet)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync());
    }

    public async Task<IEnumerable<ClinicVisit>> FindAll()
    {
        return (await context.ClinicVisits
            .Include(c => c.Pet)
            .ToListAsync());
    }

    public Task UpdateVisit(ClinicVisit visit)
    {
        context.ClinicVisits.Update(visit);
        return context.SaveChangesAsync();
    }

    public async Task<List<ClinicVisit>> GetVisitsByPetId(Guid petId)
    {
        return await context.ClinicVisits
            .Include(c => c.Pet)
            .Where(c => c.PetId == petId)
            .ToListAsync();
    }

    public async Task<ClinicVisit?> GetVisitsByDateRange(DateTime start, DateTime end)
    {
        return await context.ClinicVisits
            .Include(c => c.Pet)
            .Where(c => c.Date >= start && c.Date <= end)
            .FirstOrDefaultAsync();
    }
    
}