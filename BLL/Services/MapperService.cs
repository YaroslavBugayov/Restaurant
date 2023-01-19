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
        
        public static Mapper UserMapper = new Mapper(userMapperConfiguration);
    }
}
