using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Interfaces;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            this._petRepository = petRepository;
        }

        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = _petRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pets);
        }

        [HttpGet("{petId}")]
        public IActionResult GetPet(int petId)
        {
            if (!_petRepository.PetExists(petId))
            {
                return NotFound();
            }

            var pet = _petRepository.GetPetById(petId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pet);
        }

        [HttpGet("{petId}/rating")]
        public IActionResult GetPetRating(int petId)
        {
            if (!_petRepository.PetExists(petId))
            {
                return NotFound();
            }

            var rating = _petRepository.GetPetRating(petId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

    }
}
