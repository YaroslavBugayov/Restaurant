using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PricelistDTO
    {
        public int Id { get; set; }
        public DishDTO DishDTO { get; set; }
        public SizeDTO SizeDTO { get; set; }
        public int Price { get; set; }
    }
}
