using BLL.DTO;

namespace PL.Models
{
    internal class PricelistModel
    {
        public int Id { get; set; }
        public DishDTO Dish { get; set; }
        public SizeDTO Size { get; set; }
        public int Price { get; set; }
    }
}
