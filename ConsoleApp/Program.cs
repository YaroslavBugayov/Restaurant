using System.Collections.Generic;
using DAL;
using DAL.Entities;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext db = new ApplicationContext();

            // Users
            User user1 = new User
            {
                Username = "Userame1",
                Email = "Email1",
                Password = "12345",
                FirstName = "FName",
                LastName = "LName"
            };

            // Ingredients
            Ingredient ingredient1 = new Ingredient { IngredientName = "Ingredient1" };

            // Sizes
            Size size = new Size { SizeName = "Small", Weight = 100 };
            Size size2 = new Size { SizeName = "Medium", Weight = 200 };

            // Dishes
            Dish dish1 = new Dish
            {
                DishName = "Dish1",
                Ingredients = new List<Ingredient> { ingredient1 }
            };

            // Pricelists
            Pricelist pricelist1 = new Pricelist
            {
                DishId = 1,
                SizeId = 1,
                Price = 100
            };

            Pricelist pricelist2 = new Pricelist
            {
                DishId = 1,
                SizeId = 2,
                Price = 200
            };

            // Orders
            //Order order1 = new Order
            //{
            //    UserId = 1,
            //    Price = 300,
            //    Pricelists= new List<Pricelist> { pricelist1, pricelist2 }
            //};

            db.Users.Add(user1);
            db.SaveChanges();
        }
    }
}
