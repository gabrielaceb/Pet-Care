using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.Repositories;

public class TreatmentRepository(ApplicationDbContext context) : ITreatmentRepository
{
    public async Task AddTreatment(Treatment treatment)
    {
       context.Treatments.Add(treatment);
       await context.SaveChangesAsync();
    }

    public async Task<Treatment?> FindById(Guid id)
    {
        return await context.Treatments.FindAsync(id);
    }

    public async Task<IEnumerable<Treatment>> FindAll()
    {
        return await context.Treatments.ToListAsync();
    }

    public Task UpdateTreatment(Treatment treatment)
    {
        context.Treatments.Update(treatment);
        return context.SaveChangesAsync();
    }

    public async Task<List<Treatment>> GetTreatmentsByPetId(Guid petId)
    {
        return await context.Treatments
            .Include(t => t.Pet)
            .Where(t => t.PetId == petId)
            .ToListAsync();
    }

    public Task<Treatment?> GetTreatmentsByDateRange(DateTime start, DateTime end)
    {
        return context.Treatments
            .Include(t => t.Pet)
            .Where(t => t.StartDate >= start && t.StartDate <= end)
            .FirstOrDefaultAsync();
    }
}