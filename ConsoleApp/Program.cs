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

            // Sizes
            Size size = new Size { Id = 1, SizeName = "Small", Weight = 100 };
            Size size2 = new Size { Id = 2, SizeName = "Medium", Weight = 200 };
            Size size3 = new Size { Id = 3, SizeName = "Large", Weight = 300 };

            Size size4 = new Size { Id = 4, SizeName = "Small", Weight = 150 };
            Size size5 = new Size { Id = 5, SizeName = "Medium", Weight = 250 };
            Size size6 = new Size { Id = 6, SizeName = "Large", Weight = 350 };

            // Dishes
            Dish dish1 = new Dish
            {
                Id = 1,
                DishName = "El la pasta",
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish2 = new Dish
            {
                Id = 2,
                DishName = "Herring under shuba",
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish3 = new Dish
            {
                Id = 3,
                DishName = "Pizza eight cheeses",
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish4 = new Dish
            {
                Id = 4,
                DishName = "Sushi",
                Ingredients = new List<Ingredient> { ingredient1 }
            };
            Dish dish5 = new Dish
            {
                Id = 5,
                DishName = "Corean carrot",
                Ingredients = new List<Ingredient> { ingredient1 }
            };

            // Pricelists
            Pricelist pricelist1 = new Pricelist
            {
                Dish = dish1,
                Size = size,
                Price = 100
            };

            Pricelist pricelist2 = new Pricelist
            {
                Dish = dish1,
                Size = size5,
                Price = 200
            };

            Pricelist pricelist3 = new Pricelist
            {
                Dish = dish2,
                Size = size6,
                Price = 210
            };

            Pricelist pricelist4 = new Pricelist
            {
                Dish = dish3,
                Size = size2,
                Price = 230
            };

            Pricelist pricelist5 = new Pricelist
            {
                Dish = dish3,
                Size = size3,
                Price = 320
            };

            Pricelist pricelist6 = new Pricelist
            {
                Dish = dish4,
                Size = size4,
                Price = 400
            };

            Pricelist pricelist7 = new Pricelist
            {
                Dish = dish4,
                Size = size5,
                Price = 500
            };

            Pricelist pricelist8 = new Pricelist
            {
                Dish = dish5,
                Size = size,
                Price = 100
            };

            //// Orders
            //Order order1 = new Order
            //{
            //    UserId = 1,
            //    Price = 300,
            //    Pricelists = new List<Pricelist> { pricelist1, pricelist2 }
            //};

            db.Sizes.Add(size);
            db.Sizes.Add(size2);
            db.Sizes.Add(size3);
            db.Sizes.Add(size4);
            db.Sizes.Add(size5);
            db.Sizes.Add(size6);

            db.Dishes.Add(dish1);
            db.Dishes.Add(dish2);
            db.Dishes.Add(dish3);
            db.Dishes.Add(dish4);
            db.Dishes.Add(dish5);

            db.Pricelists.Add(pricelist1);
            db.Pricelists.Add(pricelist2);
            db.Pricelists.Add(pricelist3);
            db.Pricelists.Add(pricelist4);
            db.Pricelists.Add(pricelist5);
            db.Pricelists.Add(pricelist6);
            db.Pricelists.Add(pricelist7);
            db.Pricelists.Add(pricelist8);

            db.SaveChanges();
        }
    }
}
