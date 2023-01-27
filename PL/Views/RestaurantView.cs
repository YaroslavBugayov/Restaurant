using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject.Modules;
using Ninject;
using PL.Presenters;
using PL.Views;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BLL.Services;
using System.Linq;
using PL.Models;
using System.Diagnostics;

namespace PL
{
    public partial class RestaurantView : Form
    {
        private static IOrderService orderService;
        private static OrderController orderController;
        private static IPricelistService pricelistService;
        private static PricelistController pricelistController;

        private List<PricelistModel> pricelists;
        private List<PricelistModel> listBoxOrdersList = 
            new List<PricelistModel>();

        public RestaurantView()
        {
            InitializeComponent();
            NinjectModule dependencies = new NinjectDependenciesModule();
            IKernel ninjectKernel = new StandardKernel(dependencies);
            orderService = ninjectKernel.Get<IOrderService>();
            orderController = new OrderController(orderService);
            pricelistService = ninjectKernel.Get<IPricelistService>();
            pricelistController = new PricelistController(pricelistService);
        }

        private void Application_Load(object sender, EventArgs e)
        {
            labelUserName.Text = "Please log in to your account";
            buttonSignOut.Hide();
            panelOrder.Hide();
            buttonPreviousOrders.Hide();

            pricelists = pricelistController.GetPricelists().ToList();
            foreach (var pricelist in pricelists)
            {
                comboBoxDishes.Items.Add(string.Format("{0} {1}",
                    pricelist.Size.SizeName, pricelist.Dish.DishName));
            }
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            new LoginPresenter(new LoginView(), this);
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            RegistrationView registerWindow = new RegistrationView(this);
            registerWindow.Show();
        }

        public void loggedIntoAccount()
        {
            var firstName = AuthorizedUserController.Get().FirstName;
            var lastName = AuthorizedUserController.Get().LastName;
            labelUserName.Text = string.Format("{0} {1}", firstName, lastName);

            buttonSignIn.Hide();
            buttonSignUp.Hide();
            buttonSignOut.Show();
            buttonPreviousOrders.Show();
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            labelUserName.Text = "Please log in to your account";
            AuthorizedUserController.Set(null);

            buttonSignIn.Show();
            buttonSignUp.Show();
            buttonSignOut.Hide();
            buttonPreviousOrders.Show();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            panelOrder.Show();
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            panelOrder.Hide();
            var dish = comboBoxDishes.SelectedItem.ToString();
            listBoxOrders.Items.Add(string.Format(dish));
            listBoxOrdersList.Add(pricelists[comboBoxDishes.SelectedIndex]);
            setPriceText();
        }

        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            listBoxOrdersList.RemoveAt(listBoxOrders.SelectedIndex);
            listBoxOrders.Items.RemoveAt(listBoxOrders.SelectedIndex);
            setPriceText();
        }

        private void buttonSendOrders_Click(object sender, EventArgs e)
        {
            if (AuthorizedUserController.Get() == null)
            {
                MessageBox.Show("Please authorize before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            orderController.MakeOrder(new OrderModel()
            {
                Price = getPrice(),
                pricelistModels = listBoxOrdersList,
                User = AuthorizedUserController.Get(),
            });

            listBoxOrders.Items.Clear();
            setPriceText();
        }

        private void comboBoxDishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = pricelists[comboBoxDishes.SelectedIndex];
            labelResultOrder.Text = string.Format("{0}\n{1}\n{2} grams\n{3} hryvnias",
               item.Dish.DishName, item.Size.SizeName, item.Size.Weight, item.Price);
        }

        private void setPriceText()
        {
            labelPrice.Text = getPrice().ToString();
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

        private void buttonPreviousOrders_Click(object sender, EventArgs e)
        {
            new CheckPresenter(new CheckView());
        }
    }
}
