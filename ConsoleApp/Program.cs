using System;
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

            //// Users
            //User user1 = new User
            //{
            //    Username = "Userame1",
            //    Email = "Email1",
            //    Password = "12345",
            //    FirstName = "FName",
            //    LastName = "LName"
            //};

            // Ingredients
            Ingredient ingredient1 = new Ingredient { IngredientName = "Genetic material" };

            //// Sizes
            //Size size = new Size { SizeName = "Small", Weight = 100 };
            //Size size2 = new Size { SizeName = "Medium", Weight = 200 };

           // Dishes
           Dish dish1 = new Dish
           {
               DishName = "El la pasta",
               Price = 300,
               Ingredients = new List<Ingredient> { ingredient1 }
           };
            Dish dish2 = new Dish
            {
                DishName = "Herring under shuba",
                Price = 200,
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish3 = new Dish
            {
                DishName = "Pizza eight cheeses",
                Price = 150,
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish4 = new Dish
            {
                DishName = "Sushi",
                Price = 500,
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish5 = new Dish
            {
                DishName = "Corean carrot",
                Price = 20,
                Ingredients = new List<Ingredient> { ingredient1 }
            };

            //// Pricelists
            //Pricelist pricelist1 = new Pricelist
            //{
            //    DishId = 1,
            //    SizeId = 1,
            //    Price = 100
            //};

            //Pricelist pricelist2 = new Pricelist
            //{
            //    DishId = 1,
            //    SizeId = 2,
            //    Price = 200
            //};

            //// Orders
            //Order order1 = new Order
            //{
            //    UserId = 1,
            //    Price = 300,
            //    Pricelists = new List<Pricelist> { pricelist1, pricelist2 }
            //};

            db.Dishes.Add(dish1);
            db.Dishes.Add(dish2);
            db.Dishes.Add(dish3);
            db.Dishes.Add(dish4);
            db.Dishes.Add(dish5);
            db.SaveChanges();
        }
    }
}
