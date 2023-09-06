using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int countryId);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnerFromCountry(int countryId);
        bool CountryExists(int countryId);
    }
}
