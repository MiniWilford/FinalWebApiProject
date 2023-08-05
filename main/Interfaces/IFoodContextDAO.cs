using Main.Model;

namespace FinalWebApiProject.Interfaces
{
    public interface IFoodContextDAO {
        List<Food> GetAllFood();
        Food GetFoodById(int id);
    }
}