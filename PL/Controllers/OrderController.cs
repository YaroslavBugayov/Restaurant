using BLL.Services;
using PL.Models;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace PL.Controllers
{
    public class OrderController
    {
        IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IEnumerable<OrderViewModel> GetUsersOrders()
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orderService.GetUsersOrders(AuthorizedUserController.Get().Id))
            {
                orderViewModels.Add(new OrderViewModel()
                {
                    Id = order.Id,
                    Price = order.Price,
                    User = new UserViewModel()
                    {
                        Id = order.User.Id,
                        Email = order.User.Email,
                        FirstName = order.User.FirstName,
                        LastName = order.User.LastName,
                        Password = order.User.Password,
                        UserName = order.User.UserName
                    },
                    pricelistViewModels = PricelistDTOtoVM(order.PricelistDTOs)
                });
            }
            return orderViewModels;
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

        private List<PricelistDTO> PricelistVMtoDTO(IEnumerable<PricelistViewModel> pricelistVM)
        {
            var pricelistDTO = new List<PricelistDTO>();
            foreach (var item in pricelistVM)
            {
                pricelistDTO.Add(new PricelistDTO()
                {
                    Id = item.Id,
                    DishDTO = item.Dish,
                    SizeDTO = item.Size,
                    Price = item.Price
                });
            }
            return pricelistDTO;
        }

        private List<PricelistViewModel> PricelistDTOtoVM(IEnumerable<PricelistDTO> pricelistDTOs)
        {
            var pricelistVMs = new List<PricelistViewModel>();
            foreach (var item in pricelistDTOs)
            {
                pricelistVMs.Add(new PricelistViewModel()
                {
                    Id = item.Id,
                    Dish = item.DishDTO,
                    Size = item.SizeDTO,
                    Price = item.Price
                });
            }
            return pricelistVMs;
        }

    }
}
