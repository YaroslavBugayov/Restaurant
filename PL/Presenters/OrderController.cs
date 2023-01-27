using BLL.Services;
using PL.Models;
using BLL.DTO;
using System.Collections.Generic;

namespace PL.Presenters
{
    public class OrderController
    {
        IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public OrderModel MakeOrder(OrderModel orderModel)
        {
            orderService.MakeOrder(MapperPresenter
                .OrderModelToDTOMapper
                .Map<OrderDTO>(orderModel));
            return orderModel;
        }

    }
}
