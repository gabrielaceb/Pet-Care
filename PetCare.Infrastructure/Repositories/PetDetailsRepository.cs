using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.Repositories;

public class PetDetailsRepository(ApplicationDbContext context) : IPetDetailsRepository
{
    public async Task AddPetDetails(PetDetails petDetails)
    {
        context.PetDetails.Add(petDetails);
        await context.SaveChangesAsync();
    }

    public async Task<PetDetails?> FindById(Guid id)
    {
        return await context.PetDetails.FindAsync(id);
    }

    public async Task<IEnumerable<PetDetails>> FindAll()
    {
        return await context.PetDetails.ToListAsync();
    }

    public Task UpdatePetDetails(PetDetails petDetails)
    {
        context.PetDetails.Update(petDetails);
        return context.SaveChangesAsync();
    }

    public async Task<List<PetDetails>> GetPetDetailsByPetId(Guid petId)
    {
        return await context.PetDetails
            .Include(p => p.Pet)
            .Where(p => p.PetId == petId)
            .ToListAsync();
    }

    public async Task<PetDetails?> GetPetDetailsByDateRange(DateTime start, DateTime end)
    {
        return await context.PetDetails
            .Include(p => p.Pet)
            .Where(p => p.CreatedAt >= start && p.CreatedAt <= end)
            .FirstOrDefaultAsync();
    }
}