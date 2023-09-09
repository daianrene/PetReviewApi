using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface ISpecieRepository
    {
        ICollection<Specie> GetSpecies();
        Specie GetSpecieById(int specieId);
        ICollection<Pet> GetPetBySpecie(int specieId);
        bool SpecieExists(int specieId);
        bool CreateSpecie(Specie specie);

        bool UpdateSpecie(Specie specie);
        bool DeleteSpecie(Specie specie);
        bool Save();

    }
}
