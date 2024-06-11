using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Interfaces;
using PetCare.Domain.Models.Pet;

namespace PetCare.Infrastructure.Repositories;

public class PetRepository(ApplicationDbContext context) : IPetRepository
{
    public async Task AddPet(Pet pet)
    {
        context.Pets.Add(pet);
        await context.SaveChangesAsync();
    }

    public async Task<Pet?> FindById(Guid id)
    {
        return( await context.Pets
            .Include(p => p.ClinicVisits)
            .Include(p => p.Vaccines)
            .Include(p => p.Treatments)
            .Include(p =>p.PetDetails)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync());
    }

    public async Task<IEnumerable<Pet>> FindAll()
    {
        return (await context.Pets
            .Include(p => p.ClinicVisits)
            .Include(p => p.Vaccines)
            .Include(p => p.Treatments)
            .Include(p => p.PetDetails)
            .ToListAsync());
        
    }

    public  Task UpdatePet(Pet pet)
    {
        context.Pets.Update(pet);
        return context.SaveChangesAsync();
    }

    public async Task RemovePet(Guid id)
    {
        context.Pets.Remove(context.Pets.Find(id)); 
        await context.SaveChangesAsync();
    }
    
    public async Task RemovePet(Pet pet)
    {
        context.Pets.Remove(pet);
        await context.SaveChangesAsync();
    }
    
}