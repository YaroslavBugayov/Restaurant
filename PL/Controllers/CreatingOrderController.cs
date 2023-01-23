using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controllers
{
    internal static class CreatingOrderController
    {
        private static List<PricelistDTO> pricelists = new List<PricelistDTO>();

        public static void AddPriceList(int dishId, int sizeId, int price)
        {
            var pricelist = new PricelistDTO()
            {
                DishId = dishId,
                SizeId = sizeId,
                Price = price
            };
            pricelists.Add(pricelist);
        }

        public static void Clear()
        {
            pricelists.Clear();
        }
    }
}
