using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Ninject;
using PL.Models;
using PL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PL.Presenters
{
    internal class RestaurantPresenter
    {
        private RestaurantView view;
        private static IOrderService orderService;
        private static IPricelistService pricelistService;
        private List<PricelistModel> pricelists = new List<PricelistModel>();
        private List<PricelistModel> listBoxOrdersList = new List<PricelistModel>();

        public RestaurantPresenter(RestaurantView view)
        {
            this.view = view;
            IKernel ninjectKernel = new StandardKernel(new NinjectDependenciesModule());
            orderService = ninjectKernel.Get<IOrderService>();
            pricelistService = ninjectKernel.Get<IPricelistService>();

            this.view.LoadEvent += Load;
            this.view.SignOutEvent += SignOut;
            this.view.SignInEvent += SignIn;
            this.view.SignUpEvent += SignUp;
            this.view.AddOrderEvent += AddOrder;
            this.view.RemoveOrderEvent += RemoveOrder;
            this.view.IndexChangedEvent += IndexChanged;
            this.view.SendOrderEvent += SendOrder;
            this.view.PreviousOrdersEvent += PreviousOrders;
        }

        public void Run()
        {
            view.Show();
        }

        public void Load(object sender, EventArgs e)
        {
            view.Username = "Please log in to your account";

            pricelists = MapperPresenter
                .PricelistDTOtoModelMapper
                .Map<IEnumerable<PricelistDTO>, IEnumerable<PricelistModel>>
                (pricelistService.GetPricelists()).ToList();

            var dishes = new List<string>();

            foreach (var pricelist in pricelists)
            {
                dishes.Add(string.Format("{0} {1}",
                    pricelist.Size.SizeName, pricelist.Dish.DishName));
            }
            dishes.ForEach(item => view.ComboBoxDishesItem = item);
        }

        public void SignOut(object sender, EventArgs e)
        {
            view.Username = "Please log in to your account";
            AuthorizedUserPresenter.Set(null);
        }

        public void SignIn(object sender, EventArgs e)
        {
            var logView = new LoginView();
            new LoginPresenter(logView);
            logView.LoggedEvent += Logged;
        }

        public void SignUp(object sender, EventArgs e)
        {
            var regView = new RegistrationView();
            new RegistrationPresenter(regView);
            regView.LoggedEvent += Logged;
        }

        private void AddOrder(object sender, EventArgs e)
        {
            view.ListBoxOrdersItem = string.Format(view.ComboBoxDishesItem);
            listBoxOrdersList.Add(pricelists[view.ComboBoxDishesIndex]);
            view.Price = getPrice();
        }

        private int getPrice()
        {
            int resultPrice = 0;
            foreach (var item in listBoxOrdersList)
            {
                resultPrice += item.Price;
            }
            return resultPrice;
        }

        private void RemoveOrder(object sender, EventArgs e)
        {
            listBoxOrdersList.RemoveAt(view.ListBoxOrdersIndex);
            view.ListBoxOrdersRemoveIndex = view.ListBoxOrdersIndex;
            view.Price = getPrice();
        }

        private void IndexChanged(object sender, EventArgs e)
        {
            var item = pricelists[view.ComboBoxDishesIndex];
            view.ResultOrder = string.Format("{0}\n{1}\n{2} grams\n{3} hryvnias",
               item.Dish.DishName, item.Size.SizeName, item.Size.Weight, item.Price);
        }

        private void SendOrder(object sender, EventArgs e)
        {
            if (AuthorizedUserPresenter.Get() == null)
            {
                MessageBox.Show("Please authorize before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            orderService.MakeOrder(MapperPresenter
                .OrderModelToDTOMapper
                .Map<OrderDTO>(new OrderModel()
                {
                    Price = getPrice(),
                    pricelistModels = listBoxOrdersList,
                    User = AuthorizedUserPresenter.Get(),
                }));

            view.ListBoxOrdersClear();
            view.Price = 0;
        }

        private void PreviousOrders(object sender, EventArgs e)
        {
            new CheckPresenter(new CheckView());
        }

        private void Logged(object sender, EventArgs e)
        {
            var firstName = AuthorizedUserPresenter.Get().FirstName;
            var lastName = AuthorizedUserPresenter.Get().LastName;
            view.Username = string.Format("{0} {1}", firstName, lastName);
            view.loggedIntoAccount();
        }
    }
}
