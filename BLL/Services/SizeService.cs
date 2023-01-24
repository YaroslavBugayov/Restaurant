using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SizeService : ISizeService
    {
        IUnitOfWork Database { get; set; }
        public SizeService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public SizeDTO GetSize(int sizeId)
        {
            var size = Database.Sizes.Find(_size => _size.Id.Equals(sizeId)).FirstOrDefault();
            if (size != null)
            {
                return MapperService.SizeMapper.Map<SizeDTO>(size);
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
