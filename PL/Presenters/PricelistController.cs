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

namespace PL.Presenters
{
    public class PricelistController
    {
        private readonly IPricelistService pricelistService;
        public PricelistController(IPricelistService pricelistService)
        {
            this.pricelistService = pricelistService;
        }

        public ICollection<PricelistModel> GetPricelists()
        {
            ICollection<PricelistModel> pricelists = new List<PricelistModel>();
            //try
            //{
                var pricelistDTOs = pricelistService.GetPricelists();

                foreach (PricelistDTO pricelistDTO in pricelistDTOs)
                {
                    pricelists.Add(new PricelistModel()
                    {
                        Id = pricelistDTO.Id,
                        Dish = pricelistDTO.Dish,
                        Size = pricelistDTO.Size,
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
