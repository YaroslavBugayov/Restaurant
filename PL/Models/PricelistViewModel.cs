﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class PricelistViewModel
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int SizeId { get; set; }
        public int Price { get; set; }
    }
}
