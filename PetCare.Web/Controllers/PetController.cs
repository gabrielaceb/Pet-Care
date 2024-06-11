using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using PetCare.Aplication.UseCases;
using PetCare.Common.DTO;
using PetCare.Domain.Models.Pet;

namespace PetCare.Web.Controllers;

[ApiController]
[Route("PetCare/")]

public class PetController : ControllerBase
{
    private readonly PetUseCase _petUseCase;
    
    public PetController(PetUseCase petUseCase)
    {
        _petUseCase = petUseCase;
    }
    
    [HttpGet("Pet")]
    [RequireAntiforgeryToken]
    public async Task<IActionResult> GetPet()
    {
        var pets = await _petUseCase.FindAllPets();
        return Ok(pets);
    }
    
    [HttpPost("Pet")]
    [RequireAntiforgeryToken]
    public async Task<IActionResult> AddPet([FromBody] PetDTO petDto)
    {
        var pet = new Pet()
        {
            Name = petDto.Name,
            Breed = petDto.Breed,
            Color = petDto.Color,
            Description = petDto.Description,
            PetType = petDto.PetType,
            BirthDate = petDto.BirthDate,
            ImagePath = petDto.ImagePath,
            LastClinicVisit = petDto.LastClinicVisit,
            PetDetails = new List<PetDetails>()
            {
                new PetDetails()
                {
                    Weight = petDto.Weight,
                    Height = petDto.Height,
                    CreatedAt = DateTime.Now
                }
            }
        };
        
        await _petUseCase.AddPet(pet);
        return Ok();
    }
    
}