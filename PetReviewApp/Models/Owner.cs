namespace PetReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Country Country { get; set; }
        public ICollection<Pet> Pets { get; set; }


    }
}
