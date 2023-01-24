using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject.Modules;
using Ninject;
using PL.Controllers;
using PL.Views;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using BLL.Services;
using Ninject.Infrastructure.Language;
using System.Linq;
using System.Diagnostics;
using PL.Models;
using BLL.DTO;

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
        private string size;
        private List<KeyValuePair<string, int>> listBoxOrdersList = 
            new List<KeyValuePair<string, int>>();

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

            pricelists = pricelistController.GetPricelists().ToList();
            foreach (var pricelist in pricelists)
            {
                comboBoxDishes.Items.Add(string.Format("{0} {1}",
                    pricelist.Size.SizeName, pricelist.Dish.DishName));
            }

            radioButtonSmall.Checked = true;
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
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            labelUserName.Text = "Please log in to your account";
            AuthorizedUserController.Set(null);

            buttonSignIn.Show();
            buttonSignUp.Show();
            buttonSignOut.Hide();
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
            var tempPrice = pricelists[comboBoxDishes.SelectedIndex].Price;
            
            listBoxOrdersList.Add(
                new KeyValuePair<string, int>(comboBoxDishes.SelectedText, tempPrice)
                );
            setPriceText();
        }

        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            listBoxOrdersList.RemoveAt(listBoxOrders.SelectedIndex);
            listBoxOrders.Items.RemoveAt(listBoxOrders.SelectedIndex);
            setPriceText();
        }

        private void radioButtonSmall_CheckedChanged(object sender, EventArgs e)
        {
            size = "Small";
        }

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            size = "Medium";
        }

        private void radioButtonLarge_CheckedChanged(object sender, EventArgs e)
        {
            size = "Large";
        }

        private void buttonSendOrders_Click(object sender, EventArgs e)
        {
            if (AuthorizedUserController.Get() == null)
            {
                MessageBox.Show("Please authorize before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            foreach (var item in listBoxOrders.Items)
            {
                //Debug.WriteLine(dishController.GetDishDTO(item.ToString()));
            }

            CreatingOrderController.Clear();
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
            int resultPrice = 0;
            foreach (var item in listBoxOrdersList)
            {
                resultPrice += item.Value;
            }
            labelPrice.Text = resultPrice.ToString();
        }
    }
}
