using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MiniProjekt.Migrations;
using MiniProjekt.Views.eSpensa;

namespace MiniProjekt.Models
{
    public class DataService : IDataService
    {
        public DataService(ApplicationContext context)
        {
            Context = context;
        }

        public ApplicationContext Context;

        public async Task<IndexVM> GetIndexVM()
        {
            var expiringSoon = Context.FoodItems.Where(o => o.ExpirationDate.AddDays(-5) < DateTime.Now).Count();

            return new IndexVM { ExpiringSoon = expiringSoon, InMyShoppingListCount = 0 };
        }

        public MyFoodVM GetMyFoodVM()
        {
            int referencedate = DateOnly.FromDateTime(DateTime.Now).DayNumber;
            return new MyFoodVM
            {
                ItemsInFridgeCount = Context.FoodItems.Where(o => o.GoesInTheFridge).Count(),
                ItemsInPentryCount = Context.FoodItems.Where(o => !o.GoesInTheFridge).Count(),
                ConsumeSoon = Context.FoodItems.Where(o => o.ExpirationDate.AddDays(-5) < DateTime.Now).Count()
            };
        }

        public void AddFood(AddItemToMyFoodVM model)
        {
            Context.FoodItems.Add(new FoodItem
            {
                Name = model.Name,
                ExpirationDate = model.ExpirationDate,
                FoodGroup = model.FoodGroup,
                GoesInTheFridge = model.GoesInTheFridge,
            });
            Context.SaveChanges();
        }

        public FoodListVM GetFoodListVM(string listName)
        {
            var reference = DateTime.Now;
            var foodsInList = Context.FoodItems.Select(o => new FoodListVM.FoodItemVM
            {
                ItemName = o.Name,
                Id = o.Id,
                IsRefrigerated = o.GoesInTheFridge,
                FoodGroup = o.FoodGroup.ToString(),
                ExpirationDate = o.ExpirationDate,
            }).ToArray();

            switch (listName)
            {
                case "Fridge":
                    foodsInList = foodsInList.Where(o => o.IsRefrigerated).ToArray();
                    break;
                case "Pentry":
                    foodsInList = foodsInList.Where(o => !o.IsRefrigerated).ToArray();
                    break;
                case "Expiring":
                    foodsInList = foodsInList.Where(o => (o.ExpirationDate.AddDays(-5) < DateTime.Now)).ToArray();
                    break;
                case "All":  
                    break;
            }

            return new FoodListVM { Name = listName, FoodsList = foodsInList};
        }

        public void RemoveFoodItemByID(int id)
        {
            var toRemove = Context.FoodItems.Single(o => o.Id == id);
            Context.FoodItems.Remove(toRemove);
            Context.SaveChanges();
        }
    }
}
