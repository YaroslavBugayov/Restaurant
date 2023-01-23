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
using Ninject.Infrastructure.Language;
using System.Linq;
using System.Diagnostics;

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

        private Dictionary<string, int> dishes;
        private List<string> dishNames;
        private string size;

        public RestaurantWindow()
        {
            InitializeComponent();
            NinjectModule dependencies = new NinjectDependenciesModule();
            IKernel ninjectKernel = new StandardKernel(dependencies);
            userService = ninjectKernel.Get<IUserService>();
            userController = new UserController(userService);
            dishService = ninjectKernel.Get<IDishService>();
            dishController = new DishController(dishService);
            orderService = ninjectKernel.Get<IOrderService>();
            orderController = new OrderController(orderService);
        }

        private void Application_Load(object sender, EventArgs e)
        {
            labelUserName.Text = "Please log in to your account";
            buttonSignOut.Hide();
            panelOrder.Hide();

            dishes = dishController.GetDishes();
            dishNames = dishes.Keys.ToList();

            foreach (var elem in dishes)
            {
                comboBoxDishes.Items.Add(string.Format("{0} - {1} hryvnias",
                    elem.Key, elem.Value));
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
            var dish = dishNames[comboBoxDishes.SelectedIndex];
            var size = this.size;
            listBoxOrders.Items.Add(string.Format("{0} {1}", dish, size));
        }

        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            listBoxOrders.Items.RemoveAt(listBoxOrders.SelectedIndex);
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
            listBoxOrders.Items.Clear();
        }
    }
}
