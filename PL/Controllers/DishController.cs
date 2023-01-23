using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class DishController
    {
        private readonly IDishService dishService;
        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public Dictionary<string, int> GetDishes()
        {
            Dictionary<string, int> dishes = new Dictionary<string, int>();
            try
            {
                foreach (DishDTO dish in dishService.GetDishes())
                {
                    dishes.Add(dish.DishName, dish.Price);
                }
            } catch(Exception ex)
            {

            }
            return dishes;
        }
    }
}
