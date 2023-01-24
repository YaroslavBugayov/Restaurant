using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;


namespace BLL.Services
{
    public static class MapperService
    {
        private static MapperConfiguration userMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<User, UserDTO>());
        private static MapperConfiguration dishMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<Dish, DishDTO>());
        private static MapperConfiguration pricelistMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<Pricelist, PricelistDTO>());
        private static MapperConfiguration sizeMapperConfiguration = new MapperConfiguration(configuration => configuration.CreateMap<Size, SizeDTO>());

        public static Mapper UserMapper = new Mapper(userMapperConfiguration);
        public static Mapper DishMapper = new Mapper(dishMapperConfiguration);
        public static Mapper PricelistMapper = new Mapper(pricelistMapperConfiguration);
        public static Mapper SizeMapper = new Mapper(sizeMapperConfiguration);
    }
}
