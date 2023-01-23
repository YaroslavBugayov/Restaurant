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

        private List<string> dishes;
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

            dishes = dishController.GetDishNames();
            
            comboBoxDishes.Items.AddRange(dishes.ToArray());
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
            var dish = dishes[comboBoxDishes.SelectedIndex];
            var size = this.size;
            listBoxOrders.Items.Add(string.Format("{0} {1}", dish, size));
        }

        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            listBoxOrders.Items.RemoveAt(comboBoxDishes.SelectedIndex);
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
    }
}
