using AutoMapper;
using AutoMapper.Internal;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
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

        public IEnumerable<PricelistDTO> GetPricelists()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pricelist, PricelistDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Pricelist>, List<PricelistDTO>>(Database.Pricelists.GetAll());
        }

        public void MakeOrder(OrderDTO ordedDTO)
        {
            Order order = new Order
            {
                UserId = ordedDTO.UserId,
                Pricelists = (ICollection<Pricelist>)ordedDTO.PricelistDTOs,
                Price = ordedDTO.PricelistDTOs.Sum(pl => pl.Price),
            };
            Database.Orders.Create(order);
            Database.Save();
        }
    }
}
