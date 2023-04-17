namespace MiniProjekt.Views.eSpensa
{
    public class FoodListVM
    {
        public string Name { get; set; }
        public FoodItemVM[] FoodsList { get; set; }

        public class FoodItemVM
        {
            public int Id { get; set; }
            public string ItemName { get; set; }

            public string FoodGroup { get; set; }

            public DateTime ExpirationDate { get ; set; }

            public bool IsRefrigerated { get; set; }

        }
    }
}
