using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Presenters
{
    public static class AuthorizedUserPresenter
    {
        private static UserModel user;
        public static UserModel Get()
        {
            return user;
        }

        public static void Set(UserModel userModel) 
        {
            user = userModel;
        }
    }
}
