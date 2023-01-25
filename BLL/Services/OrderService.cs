using AutoMapper;
using AutoMapper.Internal;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
        public OrderService(IUnitOfWork unitOfWork) 
        {
            Database = unitOfWork;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<OrderDTO> GetUsersOrders(int id)
        {
            var orderDTOs = new List<OrderDTO>();
            foreach (var order in Database.Orders.GetAll().Where(o => o.UserId.Equals(id))) 
            {
                orderDTOs.Add(new OrderDTO()
                {
                    Id = order.Id,
                    Price = order.Price,
                    User = MapperService.UserMapper.Map<UserDTO>(order.User),
                    PricelistDTOs = MapperService.PricelistMapper.Map<IEnumerable<Pricelist>, IEnumerable<PricelistDTO>>(order.Pricelists)
                });
            }
            return orderDTOs;
        }

        public void MakeOrder(OrderDTO ordedDTO)
        {
            Order order = new Order
            {
                UserId = ordedDTO.User.Id,
                Pricelists = MapperService.PricelistDTOtoEntityMapper.Map<IEnumerable<PricelistDTO>, ICollection<Pricelist>>(ordedDTO.PricelistDTOs),
                Price = ordedDTO.Price,
            };
            Database.Orders.Create(order);
            Database.Save();
        }

    }
}
