using Microsoft.AspNetCore.Mvc;
using PetReviewApp.Interfaces;

namespace PetReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries();
            if (countries == null)
            {
                return NotFound();
            }
            return Ok(countries);
        }
    }
}
