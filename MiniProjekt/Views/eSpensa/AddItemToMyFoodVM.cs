using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using MiniProjekt.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MiniProjekt.Views.eSpensa
{
    public class AddItemToMyFoodVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a name"), Display(Name = "Food Name")]
        public string Name { get; set; }

        [Display(Name = "Does it go in the fridge?")]
        public bool GoesInTheFridge { get; set; }

        [Required(ErrorMessage = "Enter an expiration date"), Display(Name = "Expiration Date")]
        [DataType(DataType.Date), CustomDate(ErrorMessage = "You're not a time traveller!")]
        //[CustomDate]
        public DateTime ExpirationDate { get; set; }

        [EnumDataType(typeof(FoodGroupEnum)), Display(Name = "Food Group")]
        public FoodGroupEnum FoodGroup { get; set; }
    }

    public class CustomDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) 
            {
                return true;
            }

            var date = DateTime.Parse(value.ToString());

            return date >= DateTime.Now && date <= DateTime.Now.AddYears(5);
        }
    }
}


