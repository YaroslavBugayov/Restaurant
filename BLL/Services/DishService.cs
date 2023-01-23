﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DishService : IDishService
    {
        IUnitOfWork Database { get; set; }
        public DishService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<DishDTO> GetDishes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dish>, List<DishDTO>>(Database.Dishes.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}