using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Chef> Chefs { get; set; }

        public DbSet<Dish> Dishes { get; set; }

    }
}







// using Microsoft.EntityFrameworkCore;

// namespace  ChefsAndDishes.Models
// {
//     public class ChefDishContext : DbContext
//     {
//         // base() calls the parent class' constructor passing the "options" parameter along
//         public ChefDishContext(DbContextOptions options) : base(options) { }
//         public DbSet<Dish> Dishes { get; set; }
//         public DbSet<Chef> Chefs { get; set; }
//     }
// }