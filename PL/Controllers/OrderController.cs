using BLL.Services;
using PL.Models;
using BLL.DTO;
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

        public OrderViewModel MakeOrder(OrderViewModel orderViewModel)
        {
            var pricelistDTO = PricelistVMtoDTO(orderViewModel.pricelistViewModels);
            orderService.MakeOrder(new OrderDTO()
            {
                PricelistDTOs = pricelistDTO,
                User = new UserDTO()
                {
                    Id = orderViewModel.User.Id,
                    Email = orderViewModel.User.Email,
                    UserName = orderViewModel.User.UserName,
                    FirstName = orderViewModel.User.FirstName,
                    LastName = orderViewModel.User.LastName,
                    Password = orderViewModel.User.Password
                },
                Price = orderViewModel.Price
            });
            return orderViewModel;
        }

        private List<PricelistDTO> PricelistVMtoDTO(ICollection<PricelistViewModel> pricelistVM)
        {
            var pricelistDTO = new List<PricelistDTO>();
            foreach (var item in pricelistVM)
            {
                pricelistDTO.Add(new PricelistDTO()
                {
                    DishId = item.Dish.Id,
                    SizeId = item.Size.Id,
                    Price = item.Price
                });
            }
            return pricelistDTO;
        }

    }
}
