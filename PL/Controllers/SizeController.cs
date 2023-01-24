using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class SizeController
    {
        private readonly ISizeService sizeService;
        public SizeController(ISizeService sizeService)
        {
            this.sizeService = sizeService;
        }
        public SizeDTO GetDishDTO(int id)
        {
            return sizeService.GetSize(id);
        }
    }
}
