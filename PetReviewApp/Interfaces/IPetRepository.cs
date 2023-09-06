using PetReviewApp.Models;

namespace PetReviewApp.Interfaces
{
    public interface IPetRepository
    {
        ICollection<Pet> GetAll();
        Pet GetPetById(int id);
        Pet GetPetByName(string name);
        decimal GetPetRating(int id);
        bool PetExists(int id);
    }
}
