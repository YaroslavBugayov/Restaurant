using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Price { get; set; }
        public ICollection<PricelistViewModel> pricelistViewModels { get; set; }
    }
}
