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

        public IEnumerable<PricelistDTO> GetPricelists()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pricelist, PricelistDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Pricelist>, List<PricelistDTO>>(Database.Pricelists.GetAll());
        }

        public void MakeOrder(OrderDTO ordedDTO)
        {
            Order order = new Order
            {
                User = MapperService.UserMapperDTOtoEntity.Map<User>(ordedDTO.User),
                Pricelists = PricelistDTOtoEntity(ordedDTO.PricelistDTOs),
                Price = ordedDTO.Price,
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        private List<Pricelist> PricelistDTOtoEntity(ICollection<PricelistDTO> listDTOs)
        {
            var list = new List<Pricelist>();
            foreach (var item in listDTOs)
            {
                list.Add(MapperService.PricelistDTOtoEntity.Map<Pricelist>(item));
            }
            return list;
        }

    }
}
