using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }


        [Required(ErrorMessage="First Name is required.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage="Last Name is required.")]
        public string LastName { get; set; }


        [Required(ErrorMessage="Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        // Navigation property for related Message objects
        // A Chef can create many dishes
        // Not stored in databas
        public List<Dish> CreatedDishes { get; set; }

    }
}









// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;

// namespace ChefsAndDishes.Models
// {
//     public class Dish
//     {
//         [Key]
//         public int DishId { get; set; }
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
//         public Chef Creator { get; set; }
//         public DateTime CreatedAt { get; set; } = DateTime.Now;
//         public DateTime UpdatedAt { get; set; } = DateTime.Now;
//     }

//     public class Chef
//     {
//         [Key]
//         public int ChefId { get; set; }
//         [Required(ErrorMessage = "Chef's First Name is required")]
//         [Display(Name = "First Name:")]
//         public string FirstName { get; set; }

//         [Required(ErrorMessage = "Chef's Last Name is required")]
//         [Display(Name = "Last Name:")]
//         public string LastName { get; set; }

//         [Required(ErrorMessage = "DOB is required")]
//         [Display(Name = "Date of Birth:")]
//         public DateTime DateofBirth{get;set;}

//         public List<Dish> CreatedDishes { get; set; }
//         public DateTime CreatedAt { get; set; } = DateTime.Now;
//         public DateTime UpdatedAt { get; set; } = DateTime.Now;
//     }
// }