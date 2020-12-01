using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }


        [Required(ErrorMessage="Dish Name is required.")]
        public string DishName { get; set; }


        [Required(ErrorMessage="Amount of calories is required.")]
        [Range(0,10000, ErrorMessage="Calorie count must be greater than 0.")]
        public int Calories { get; set; }


        [Required(ErrorMessage="Description is required.")]
        [MinLength(2, ErrorMessage="Description must be longer than 2 characters.")]
        public string Description { get; set; }


        [Required]
        [Range(1,5, ErrorMessage="Tastiness must be between 1-5!")]
        public int Tastiness { get; set; }


        // This is the foreign key
        public int ChefId { get; set; }

        // Navigation property for related Chef object
        // A dish can have only one Chef that creates it
        // Not stored in database
        public Chef Creator { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}






// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;

// namespace ChefsAndDishes.Models
// {
//     public class NewDishModel
//     {
       
//         [Required(ErrorMessage = "Dish Name is required")]
//         // [MinLength(4)]
//         [Display(Name = "Name of Dish:")]
//         public string DishName { get; set; }
//         [Display(Name = "Description:")]
//         public string Description { get; set; }
//         [Required(ErrorMessage = "Calories is required")]
//         [Display(Name = "Calories:")]
//         [Range(1, int.MaxValue,ErrorMessage = "Calories must be greater then 0")]
//         public int Calories { get; set; }
//         [Required(ErrorMessage = "Tastiness is required")]
//         [Display(Name = "Tastiness:")]
//         [Range(1, 5)]
//         public int Tastiness { get; set; }
//         // The MySQL DATETIME type can be represented by a DateTime
//         public int ChefId { get; set; }
//         // Navigation property for related User object
//         public List<Chef> allchefs;
//     }


// }