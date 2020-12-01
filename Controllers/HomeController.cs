using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context { get; set; }
        public HomeController(MyContext context)
        {
            _context = context;
        }



        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> ChefwithDishes = _context.Chefs
            .Include(chef => chef.CreatedDishes)
            .ToList();
            return View(ChefwithDishes);
        }

    

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }



        [HttpPost("addchef")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("NewChef");
            }
        }



        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> DishesWithChef = _context.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View(DishesWithChef);
        }



        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.Chefs = _context.Chefs.ToList();

            return View("NewDish");
        }



        [HttpPost("adddish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return Redirect("Dishes");
            }
            else
            {
                ViewBag.Chefs = _context.Chefs.ToList();
                return View("NewDish");
            }
        }

    }
}







// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using ChefsAndDishes.Models;
// using Microsoft.EntityFrameworkCore;

// namespace ChefsAndDishes.Controllers
// {
//     public class HomeController : Controller
//     {
//         private ChefDishContext dbContext;
//         public HomeController(ChefDishContext context)
//         {
//             dbContext = context;
//         }
        
//         [Route("")]
//         [HttpGet]
//         public IActionResult Index()
//         {
//             List<Chef> ChefwithDishes = dbContext.Chefs
//             .Include(chef => chef.CreatedDishes)
//             .ToList();
//             return View(ChefwithDishes);
//         }

//         [Route("new")]
//         [HttpGet]
//         public IActionResult NewChefView()
//         {
//             return View("NewChef");
//         }

//         [Route("NewChef")]
//         [HttpPost]
//         public IActionResult NewChef(Chef newChef)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return View("NewChef");
//             }
//             else
//             {
//                 DateTime now = DateTime.Today;
//                 if (DateTime.Compare( now,newChef.DateofBirth) < 0)
//                 {
//                     ModelState.AddModelError("DateofBirth", "DOB must earlier then current date");
//                     return View("NewChef");
//                 }
//                 else
//                 {
//                     int age = now.Year - newChef.DateofBirth.Year;
//                     if(age<18)
//                     {
//                         ModelState.AddModelError("DateofBirth", "A chef  must older then 18");
//                         return View("NewChef");
//                     }
//                     else
//                     {
//                         dbContext.Chefs.Add(newChef);
//                         dbContext.SaveChanges();
//                         return Redirect("/");
//                     }

//                 }
//             }
//         }

//         [Route("dishes")]
//         [HttpGet]
//         public IActionResult Dishes()
//         {
//             List<Dish> DisheswithChef = dbContext.Dishes
//            .Include(dish => dish.Creator)
//            .ToList();
//             return View(DisheswithChef);
//         }

//         [Route("dishes/new")]
//         [HttpGet]
//         public IActionResult NewDishView()
//         {
//             List<Chef> allChef = dbContext.Chefs.ToList();
//             NewDishModel newdish =  new NewDishModel();
//             newdish.allchefs = allChef;
//             return View("NewDish",newdish);
//         }

//         [Route("NewDish")]
//         [HttpPost]
//         public IActionResult NewDish(NewDishModel newDishmodel)
//         {
//             if (!ModelState.IsValid)
//             {
//                 List<Chef> allChef = dbContext.Chefs.ToList();
//                 NewDishModel newdish = new NewDishModel();
//                 newdish.allchefs = allChef;
//                 return View("NewDish", newdish);
//             }
//             else
//             {
//                         Dish newdish = new Dish();
//                         newdish.DishName = newDishmodel.DishName;
//                         newdish.ChefId = newDishmodel.ChefId;
//                         newdish.Description = newDishmodel.Description;
//                         newdish.Calories = newDishmodel.Calories;
//                         newdish.Tastiness = newDishmodel.Tastiness;
//                         dbContext.Dishes.Add(newdish);
//                         dbContext.SaveChanges();
//                         return Redirect("dishes");
//             }
//         }


//     }
// }