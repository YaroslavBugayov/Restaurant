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

                NinjectModule dependencies = new NinjectDependenciesModule();
                IKernel ninjectKernel = new StandardKernel(dependencies);
                var dishService = ninjectKernel.Get<IDishService>();
                var dishController = new DishController(dishService);
                var sizeService = ninjectKernel.Get<ISizeService>();
                var sizeController = new SizeController(sizeService);

                foreach (PricelistDTO pricelistDTO in pricelistDTOs)
                {
                    pricelists.Add(new PricelistViewModel()
                    {
                        Dish = dishService.GetDish(pricelistDTO.DishId),
                        Size = sizeService.GetSize(pricelistDTO.SizeId),
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
