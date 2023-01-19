using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.UnitOfWork;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class NinjectDependenciesModule : NinjectModule
    {
        //private string connectionString;
        //public NinjectDependenciesModule(string connection)
        //{
        //    connectionString = connection;
        //}
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            //Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
