namespace MiniProjekt.Views.eSpensa
{
    public class MyFoodVM
    {
        public int ItemsInFridgeCount { get; set; }
        public int ItemsInPentryCount { get; set; }
        public int AllFoodCount { get => ItemsInFridgeCount + ItemsInPentryCount; }
        public int ConsumeSoon { get; set; }

        public class FoodItemVM
        {
            public int Id { get; set; }
            public string ItemName { get; set; }

        }
    }
}
