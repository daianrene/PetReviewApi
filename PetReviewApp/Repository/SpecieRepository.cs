using PetReviewApp.Data;
using PetReviewApp.Interfaces;
using PetReviewApp.Models;

namespace PetReviewApp.Repository
{
    public class SpecieRepository : ISpecieRepository
    {
        private readonly DataContext _context;

        public SpecieRepository(DataContext context)
        {
            this._context = context;
        }
        public ICollection<Pet> GetPetBySpecie(int specieId)
        {
            return _context.Pets.Where(p => p.Specie.Id == specieId).ToList();
        }

        public Specie GetSpecieById(int specieId)
        {
            return _context.Species.Where(e => e.Id == specieId).FirstOrDefault();
        }

        public ICollection<Specie> GetSpecies()
        {
            return _context.Species.ToList();
        }

        public bool SpecieExists(int specieId)
        {
            return _context.Species.Any(e => e.Id == specieId);
        }
    }
}
