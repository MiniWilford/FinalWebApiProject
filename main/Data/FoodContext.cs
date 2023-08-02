using Microsoft.EntityFrameworkCore;

namespace Main.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Food>().HasData(
                new Food{FoodId = 1, FoodName = "Pizza", FoodDescription = "Round and cheesey", FoodType = "Carbohydrates", FoodColor = "Mixed"},
                new Food{FoodId = 2, FoodName = "Tomato", FoodDescription = "Red and round", FoodType = "Vegetable", FoodColor = "Red"}
           );
        }


        public DbSet<Food> Food {get; set;}
    }
}
