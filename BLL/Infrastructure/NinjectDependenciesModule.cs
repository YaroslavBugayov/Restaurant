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
            Bind<IDishService>().To<DishService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IPricelistService>().To<PricelistService>();
            Bind<ISizeService>().To<SizeService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            //Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
