using Microsoft.EntityFrameworkCore;

namespace Main.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Books>().HasData(
                new Books{ISBN = 9781400226573, Title = "Don't Look Back", Genre = "Mystery/Fiction", Author = "Jennifer L. Armentrout", Year = 2014},
                new Books{ISBN = 9780547928227, Title = "The Hobbit", Genre = "Fantasy", Author = "J.R.R. Tolkien", Year = 1937},
                new Books{ISBN = 9780345806789, Title = "The Shining", Genre = "Horror/Fiction", Author = "Stephen King", Year = 1977},
                new Books{ISBN = 9780307949486, Title = "The Girl with the Dragon Tattoo", Genre = "Thriller/Mystery", Author = "Stieg Larsson", Year = 2005},
                new Books{ISBN = 9781534483194, Title = "Remember Me", Genre = "dark Fantasy", Author = "Christopher Pike", Year = 1989}
           );
        }

        public DbSet<Books> Books {get; set;}
    }
}
