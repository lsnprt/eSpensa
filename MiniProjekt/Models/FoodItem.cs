using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MiniProjekt.Models
{
    public class FoodItem
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public bool GoesInTheFridge { get; set; }

        public DateTime ExpirationDate { get; set; }

        public FoodGroupEnum FoodGroup { get; set; }
    }
}
