using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace PL.Models
{
    public class PricelistModel
    {
        public int Id { get; set; }
        public DishDTO Dish { get; set; }
        public SizeDTO Size { get; set; }
        public int Price { get; set; }
    }
}
