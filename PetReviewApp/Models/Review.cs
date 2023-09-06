namespace PetReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
        public Reviewer Reviewer { get; set; }
        public Pet Pet { get; set; }
    }
}
