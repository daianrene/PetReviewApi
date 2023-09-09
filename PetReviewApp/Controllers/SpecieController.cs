using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

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

        [HttpPost]
        public IActionResult CreateSpecie([FromBody] Specie specieCreate)
        {
            if (specieCreate == null)
                return BadRequest();

            var specie = _specieRepository.GetSpecies().
                Where(s => s.Name.Trim().ToUpper() == specieCreate.Name.Trim().ToUpper()).
                FirstOrDefault();

            if (specie != null)
            {
                ModelState.AddModelError("", "Specie already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_specieRepository.CreateSpecie(specieCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuslly created");
        }

        [HttpPut("{specieId}")]
        public IActionResult UpdateSpecie(int specieId, [FromBody] Specie updatedSpecie)
        {
            if (updatedSpecie == null)
                return BadRequest(ModelState);

            if (specieId != updatedSpecie.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_specieRepository.SpecieExists(specieId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_specieRepository.UpdateSpecie(updatedSpecie))
            {
                ModelState.AddModelError("", "Something went wrong updating specie");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{specieId}")]
        public IActionResult DeleteSpecie(int specieId)
        {
            if (!_specieRepository.SpecieExists(specieId))
                return NotFound();

            var specie = _specieRepository.GetSpecieById(specieId);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_specieRepository.DeleteSpecie(specie))
            {
                ModelState.AddModelError("", "Something went wrong deleting specie");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
