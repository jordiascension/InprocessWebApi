using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AbastWebApi.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { 
        
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Dune: Parte 2",
                    Genre = "Ciencia Ficción",
                    ReleaseDate = new DateTime(2015, 12, 25)
                },
                new Movie
                {
                    Id = 2,
                    Title = "El clan de hierro",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(2014, 11, 26)
                }
            );
        }

        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
