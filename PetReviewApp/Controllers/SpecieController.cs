using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Interfaces;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecieController : ControllerBase
    {
        private readonly ISpecieRepository _specieRepository;

        public SpecieController(ISpecieRepository specieRepository)
        {
            this._specieRepository = specieRepository;
        }

        [HttpGet]
        public IActionResult GetSpecies()
        {
            var species = _specieRepository.GetSpecies();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(species);
        }

        [HttpGet("{specieId}")]
        public IActionResult GetSpecie(int specieId)
        {
            if (!_specieRepository.SpecieExists(specieId))
            {
                return NotFound();
            }

            var specie = _specieRepository.GetSpecieById(specieId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(specie);
        }

        [HttpGet("pet/{specieId}")]
        public IActionResult GetPetBySpecie(int specieId)
        {
            if (!_specieRepository.SpecieExists(specieId))
            {
                return NotFound();
            }
            var pets = _specieRepository.GetPetBySpecie(specieId);

            if (pets == null) return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pets);
        }

    }
}
