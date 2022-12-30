using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Entities;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pricelist> Pricelists { get; set; }
        public ApplicationContext() : base("Restaurant") {}

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder
                .Entity<Dish>()
                .HasMany<Ingredient>(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .Map(di =>
                {
                    di.MapLeftKey("DishRefId");
                    di.MapRightKey("IngredientRefId");
                    di.ToTable("DishesIngredients");
                });

            dbModelBuilder
                .Entity<Pricelist>()
                .HasRequired<Dish>(p => p.Dish)
                .WithMany(d => d.Pricelists)
                .HasForeignKey<int>(p => p.DishId);

            dbModelBuilder
                .Entity<Pricelist>()
                .HasRequired<Order>(p => p.Order)
                .WithMany(o => o.Pricelists)
                .HasForeignKey<int>(p => p.OrderId);


        }
    }
}
