using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public static class AuthorizedUserController
    {
        private static UserViewModel user;
        public static UserViewModel Get()
        {
            return user;
        }

        public static void Set(UserViewModel userViewModel) 
        {
            user = userViewModel;
        }
    }
}
