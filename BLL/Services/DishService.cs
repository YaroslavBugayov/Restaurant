using AutoMapper;
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

        public DishDTO GetDish(string dishName)
        {
            var dish = Database.Dishes.Find(_dish => _dish.DishName.Equals(dishName)).FirstOrDefault();
            if (dish != null)
            {
                return MapperService.DishMapper.Map<DishDTO>(dish);
            } else
            {
                throw new Exception();
            }
        }

        public DishDTO GetDish(int dishId)
        {
            var dish = Database.Dishes.Find(_dish => _dish.Id.Equals(dishId)).FirstOrDefault();
            if (dish != null)
            {
                return MapperService.DishMapper.Map<DishDTO>(dish);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
