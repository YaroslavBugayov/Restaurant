using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return MapperService.
                PricelistMapper.
                Map<List<Pricelist>, IEnumerable<PricelistDTO>>(Database.Pricelists.GetAll().ToList());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
