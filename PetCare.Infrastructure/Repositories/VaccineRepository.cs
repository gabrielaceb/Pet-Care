using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.Repositories;

public class VaccineRepository(ApplicationDbContext context) : IVaccineRepository
{
    
    public async Task AddVaccine(Vaccine vaccine)
    {
        context.Vaccines.Add(vaccine);
        await context.SaveChangesAsync();
    }

    public async Task<Vaccine?> FindById(Guid id)
    {
        return await context.Vaccines.FindAsync(id);
    }

    public async Task<IEnumerable<Vaccine>> FindAll()
    {
        return await context.Vaccines.ToListAsync();
    }

    public Task UpdateVaccine(Vaccine vaccine)
    {
        context.Vaccines.Update(vaccine);
        return context.SaveChangesAsync();
    }

    public async Task<List<Vaccine>> GetVaccinesByPetId(Guid petId)
    {
        return await context.Vaccines
            .Include(v => v.Pet)
            .Where(v => v.PetId == petId)
            .ToListAsync();
    }

    public async Task<Vaccine?> GetVaccinesByDateRange(DateTime start, DateTime end)
    {
        return await context.Vaccines
            .Include(v => v.Pet)
            .Where(v => v.Date >= start && v.Date <= end)
            .FirstOrDefaultAsync();
    }
    
}