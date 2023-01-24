using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject.Modules;
using Ninject;
using PL.Controllers;
using PL.Views;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BLL.Services;
using System.Linq;
using PL.Models;

namespace PL
{
    public partial class RestaurantWindow : Form
    {
        private static IUserService userService;
        private static UserController userController;
        private static IDishService dishService;
        private static DishController dishController;
        private static IOrderService orderService;
        private static OrderController orderController;
        private static IPricelistService pricelistService;
        private static PricelistController pricelistController;

        private List<PricelistViewModel> pricelists;
        private List<PricelistViewModel> listBoxOrdersList = 
            new List<PricelistViewModel>();

        public RestaurantWindow()
        {
            InitializeComponent();
            NinjectModule dependencies = new NinjectDependenciesModule();
            IKernel ninjectKernel = new StandardKernel(dependencies);
            userService = ninjectKernel.Get<IUserService>();
            userController = new UserController(userService);
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
            LoginWindow loginWindow = new LoginWindow(this);
            loginWindow.Show();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(this);
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

            orderController.MakeOrder(new OrderViewModel()
            {
                Price = getPrice(),
                pricelistViewModels = listBoxOrdersList,
                User = AuthorizedUserController.Get(),
            });

            listBoxOrders.Items.Clear();
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
    }
}
