using Microsoft.AspNetCore.Mvc;
using MiniProjekt.Views.eSpensa;
using MiniProjekt.Models;

namespace MiniProjekt.Controllers
{
    public class eSpensaController : Controller
    {
        IDataService service;

        public eSpensaController(IDataService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        [HttpGet("/Home")]
        public async Task<IActionResult> Index()
        {
            IndexVM model = await service.GetIndexVM();
            return View(model);
        }

        [HttpGet("/MyFood")]
        public IActionResult MyFood()
        {
            MyFoodVM model = service.GetMyFoodVM();
            return View(model);
        }

        [HttpGet("/MyFood/Add")]
        public IActionResult AddItemToMyFood()
        {
            return View();
        }

        [HttpPost("/MyFood/Add")]
        public IActionResult AddItemToMyFood(AddItemToMyFoodVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else
            {
                service.AddFood(model);
                return RedirectToAction(nameof(MyFood));
            }
        }

        [HttpGet("/MyFood/{listName}")]
        public IActionResult FoodList(string listName)
        {
            FoodListVM model = service.GetFoodListVM(listName);
            return View(model);
        }

        [HttpGet("MyFood/{listName}/Delete/{id}")]
        public IActionResult DeleteFoodItem(int id, string listName)
        {
            service.RemoveFoodItemByID(id);
            return RedirectToAction(nameof(FoodList), new { listName = listName });
        }


        [HttpGet("/MyLists")]
        public IActionResult MyLists()
        {
            MyListsVM model = new MyListsVM
            {
                ListOfLists = new MyListsVM.ListVM[]
                {
                    new MyListsVM.ListVM { Name = "Placeholder", ItemCount = 4},
                    new MyListsVM.ListVM { Name = "Example", ItemCount = 2},
                    new MyListsVM.ListVM { Name = "Test", ItemCount = 6}
                }
            };
            return View(model);
        }

        [HttpGet("/MyLists/{id}")]
        public IActionResult List(string id)
        {
            ListVM model = new ListVM
            {
                Name = id,
                FoodsList = new ListVM.FoodItemVM[]
                {
                    new ListVM.FoodItemVM{ ItemName = "Bananas"},
                    new ListVM.FoodItemVM{ ItemName = "Milk"},
                    new ListVM.FoodItemVM{ ItemName = "Eggs" },
                }
            };
            return View(model);
        }

        [HttpGet("MyLists/Delete/{id}")]
        [HttpPost("MyLists/Delete/{id}")]
        public IActionResult DeleteList(string id)
        {
            return RedirectToAction(nameof(MyLists));
        }
    }
}

