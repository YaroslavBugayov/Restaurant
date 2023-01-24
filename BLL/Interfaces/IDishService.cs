using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IDishService
    {
        IEnumerable<DishDTO> GetDishes();
        DishDTO GetDish(string dishName);
        DishDTO GetDish(int dishId);
        void Dispose();
    }
}
