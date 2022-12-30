using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Pricelist
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get; set; }
        public Size Size { get; set; }
        public int SizeId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
    }
}
