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

            Ingredient ingredient1 = new Ingredient { IngredientName = "Ingredient1" };
            Size size = new Size { SizeName = "Small", Weight = 100 };

            Dish dish1 = new Dish
            {
                DishName = "Dish1",
                
                Ingredients = new List<Ingredient> { ingredient1 }
            };

            //User user1 = new User
            //{
            //    Username = "Userame1",
            //    Email = "Email1",
            //    Password = "12345",
            //    FirstName = "FName",
            //    LastName = "LName",
            //    Order = new List<Dish> { dish1 }
            //};
            //User user2 = new User { Username = "Userame2", Email = "Email2", Password = "12345", FirstName = "FName", LastName = "LName" };

            db.Ingredients.Add(ingredient1);
            //db.Users.Add(user1);
            //db.Users.Add(user2);

            db.SaveChanges();
        }
    }
}
