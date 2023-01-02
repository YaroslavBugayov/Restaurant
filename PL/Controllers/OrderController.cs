using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class OrderController
    {
        IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }


    }
}
