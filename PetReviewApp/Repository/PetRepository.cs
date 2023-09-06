using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly DataContext _context;
        public PetRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Pet> GetAll()
        {
            return _context.Pets.OrderBy(p => p.Id).ToList();
        }

        public Pet GetPetById(int id)
        {
            return _context.Pets.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pet GetPetByName(string name)
        {
            return _context.Pets.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPetRating(int id)
        {
            var reviews = _context.Reviews.Where(p => p.Pet.Id == id);

            if (reviews.Count() <= 0) return 0;

            return (decimal)reviews.Sum(r => r.Rating) / reviews.Count();
        }

        public bool PetExists(int id)
        {
            return _context.Pets.Any(p => p.Id == id);
        }
    }
}
