using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public int Price { get; set; }
        public ICollection<Pricelist> Pricelists { get; set; }
        public ICollection<Ingredient> Ingredients { get; set;}
    }
}
