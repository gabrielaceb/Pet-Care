using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.StadnartValues;

namespace PetCare.Infrastructure.Repositories;

public class StVaccinesRepository(ApplicationDbContext context) : IStVaccinesRepository
{
    public async Task AddVaccine(StVaccines vaccine)
    {
        context.StVaccines.Add(vaccine);
        await context.SaveChangesAsync();
    }

    public async Task<StVaccines?> FindById(Guid id)
    {
        return await context.StVaccines.FindAsync(id);
    }

    public async Task<IEnumerable<StVaccines>> FindAll()
    {
        return await context.StVaccines.ToListAsync();
    }

    public Task UpdateVaccine(StVaccines vaccine)
    {
        context.StVaccines.Update(vaccine);
        return context.SaveChangesAsync();
    }

    public async Task<IEnumerable<StVaccines>?> GetVaccinesByDateRange(int ageStart, int ageEnd)
    {
        return await context.StVaccines
            .Where(v => v.Age >= ageStart && v.Age <= ageEnd)
            .ToListAsync();
    }

    public async Task<IEnumerable<StVaccines>> GetTopVaccines(int number)
    {
        return await context.StVaccines
            .OrderByDescending(v => v.Age)
            .Take(number)
            .ToListAsync();
    }
    
}