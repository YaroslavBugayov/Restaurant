using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using Ninject;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PL.Controllers
{
    public class PricelistController
    {
        private readonly IPricelistService pricelistService;
        public PricelistController(IPricelistService pricelistService)
        {
            this.pricelistService = pricelistService;
        }

        public ICollection<PricelistViewModel> GetPricelists()
        {
            ICollection<PricelistViewModel> pricelists = new List<PricelistViewModel>();
            //try
            //{
                var pricelistDTOs = pricelistService.GetPricelists();

                foreach (PricelistDTO pricelistDTO in pricelistDTOs)
                {
                    pricelists.Add(new PricelistViewModel()
                    {
                        Id = pricelistDTO.Id,
                        Dish = pricelistDTO.DishDTO,
                        Size = pricelistDTO.SizeDTO,
                        Price = pricelistDTO.Price,
                    });
                }
            //}
            //catch (Exception ex)
            //{
                
            //}
            return pricelists;
        }
    }
}
