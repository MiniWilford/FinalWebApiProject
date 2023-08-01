using Microsoft.EntityFrameworkCore;

namespace Main.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Movies>().HasData(
                new Movies{Id = 1, Title = "Halloween", Genre = "Horror", Director = "John Carpenter", Year = 1978},
                new Movies{Id = 2, Title = "Mask", Genre = "Comedy", Director = "Charles Russel", Year = 1994},
                new Movies{Id =3, Title = "John Wick", Genre = "Action", Director = "Chad Stahelski", Year = 2014},
                new Movies{Id = 4, Title = "Hellboy", Genre = "Fantasy/Action", Director = "Guillermo del Toro", Year = 2004},
                new Movies{Id = 5, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont", Year = 1994}
           );
        }

        public DbSet<Movies> Movie {get; set;}
    }
}
