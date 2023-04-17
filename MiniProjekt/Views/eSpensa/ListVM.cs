namespace MiniProjekt.Views.eSpensa
{
    public class ListVM
    {
        public string Name { get; set; }
        public FoodItemVM[] FoodsList { get; set; }

        public class FoodItemVM
        {
            public int Id { get; set; }
            public string ItemName { get; set; }
        }
    }
}
