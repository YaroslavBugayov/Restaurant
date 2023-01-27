using System;
using System.Collections.Generic;
using BLL.DTO;

namespace PL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public int Price { get; set; }
        public IEnumerable<PricelistModel> pricelistModels { get; set; }
    }
}
