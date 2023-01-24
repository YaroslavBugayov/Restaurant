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
    public class PricelistService : IPricelistService
    {
        IUnitOfWork Database { get; set; }
        public PricelistService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<PricelistDTO> GetPricelists()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pricelist, PricelistDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Pricelist>, List<PricelistDTO>>(Database.Pricelists.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
