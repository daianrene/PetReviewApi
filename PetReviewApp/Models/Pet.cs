namespace PetReviewApp.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public ICollection<Review> Reviews { get; set;} 
        public Owner Owner { get; set; }
        public Specie Specie { get; set; }

    }
}
