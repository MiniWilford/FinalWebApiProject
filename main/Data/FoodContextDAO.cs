using System.Linq;
using FinalWebApiProject.Interfaces;
using Main.Data;

namespace Main.Data
{
    public class FoodContextDAO : IFoodContextDAO {
        private FoodContext _context;

        public FoodContextDAO(FoodContext context) {
            _context = context;
        }

        public List<Food> GetAllFood() {
            return _context.Food.ToList();
        }

        public Food GetFoodById(int id)
        {
            return (Food)_context.Food.Where(x => x.FoodId.Equals(id)); // TODO: .FirstOrDefault()
        }
    }
}