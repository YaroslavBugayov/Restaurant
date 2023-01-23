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

        public List<string> GetDishNames()
        {
            List<string> dishes = new List<string>();
            try
            {
                foreach (DishDTO dish in dishService.GetDishes())
                {
                    dishes.Add(dish.DishName);
                }
            } catch(Exception ex)
            {

            }
            return dishes;
        }
    }
}
