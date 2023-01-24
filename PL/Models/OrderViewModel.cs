using System;
using System.Collections.Generic;
using BLL.DTO;

namespace PL.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public int Price { get; set; }
        public ICollection<PricelistViewModel> pricelistViewModels { get; set; }
    }
}
