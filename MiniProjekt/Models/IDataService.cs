using MiniProjekt.Views.eSpensa;

namespace MiniProjekt.Models
{
    public interface IDataService
    {
        void AddFood(AddItemToMyFoodVM model);
        FoodListVM GetFoodListVM(string listName);
        Task<IndexVM> GetIndexVM();
        MyFoodVM GetMyFoodVM();
        void RemoveFoodItemByID(int id);
    }
}
