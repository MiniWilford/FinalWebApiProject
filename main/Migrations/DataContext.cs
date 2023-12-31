using Microsoft.EntityFrameworkCore;
using Main.Model;

namespace Main.Migrations
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            builder.Entity<Books>().HasData(
                 new Books { ISBN = 9781400226573, Title = "Don't Look Back", Genre = "Mystery/Fiction", Author = "Jennifer L. Armentrout", Year = 2014 },
                 new Books { ISBN = 9780547928227, Title = "The Hobbit", Genre = "Fantasy", Author = "J.R.R. Tolkien", Year = 1937 },
                 new Books { ISBN = 9780345806789, Title = "The Shining", Genre = "Horror/Fiction", Author = "Stephen King", Year = 1977 },
                 new Books { ISBN = 9780307949486, Title = "The Girl with the Dragon Tattoo", Genre = "Thriller/Mystery", Author = "Stieg Larsson", Year = 2005 },
                 new Books { ISBN = 9781534483194, Title = "Remember Me", Genre = "Dark Fantasy", Author = "Christopher Pike", Year = 1989 }
            );

            // Generate Primary Key
            builder.Entity<Books>().HasKey(b =>  b.ISBN).HasName("PrimaryKey_ISBN");
          
          
        builder.Entity<Food>().HasData(
                new Food{FoodId = 1, FoodName = "Pizza", FoodDescription = "Round and cheesey", FoodType = "Carbohydrates", FoodColor = "Mixed"},
                new Food{FoodId = 2, FoodName = "Tomato", FoodDescription = "Red and round", FoodType = "Vegetable", FoodColor = "Red"}
           );
          builder.Entity<Food>().HasKey(f => f.FoodId).HasName("PrimaryKey_FoodId");


          builder.Entity<Movies>().HasData(
                new Movies{Id = 1, Title = "Halloween", Genre = "Horror", Director = "John Carpenter", Year = 1978},
                new Movies{Id = 2, Title = "Mask", Genre = "Comedy", Director = "Charles Russel", Year = 1994},
                new Movies{Id = 3, Title = "John Wick", Genre = "Action", Director = "Chad Stahelski", Year = 2014},
                new Movies{Id = 4, Title = "Hellboy", Genre = "Fantasy/Action", Director = "Guillermo del Toro", Year = 2004},
                new Movies{Id = 5, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont", Year = 1994}
           );
           builder.Entity<Movies>().HasKey(i => i.Id).HasName("PrimaryKey_BlogId");
          

           builder.Entity<Students>().HasData(
                new Students{StudentId = 1, StudentName = "Haley Beyersdoerfer", DateOfBirth = new DateTime(2001, 7, 6), StudentProgram = "Bachelors in Game Development & Design", StudentYear = 3},
                new Students{StudentId = 2, StudentName = "Kyle DeJarnett", DateOfBirth = new DateTime(2000, 6, 26), StudentProgram = "Bachelors in Information Technology", StudentYear = 2}
           );
          builder.Entity<Students>().HasKey(s => s.StudentId).HasName("PrimaryKey_StudentID");
        
        }
        public DbSet<Books> Books {get; set;}
        public DbSet<Food> Food {get; set;}
        public DbSet<Movies> Movies {get; set;}
        public DbSet<Students> Students {get; set;}

    }

}