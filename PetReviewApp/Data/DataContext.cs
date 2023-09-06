using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PetReviewApp.Models;

namespace PetReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Specie> Species { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Post>()
        //           .HasMany(e => e.Tags)
        //           .WithMany(e => e.Posts);
        //}

    }
}
