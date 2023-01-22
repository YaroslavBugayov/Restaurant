using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject.Modules;
using Ninject;
using PL.Controllers;
using PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.Views
{
    public partial class LoginWindow : Form
    {
        private static IUserService userServise;
        private static UserController userController;
        public LoginWindow()
        {
            InitializeComponent();
            NinjectModule dependencies = new NinjectDependenciesModule();
            IKernel ninjectKernel = new StandardKernel(dependencies);
            userServise = ninjectKernel.Get<IUserService>();
            userController = new UserController(userServise);
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string username = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (IsValid(username, password))
            {
                var user = userController.Authenticate(username, password);
                if (user != null)
                {
                    AuthorizedUserController.Set(user);
                    Close();
                }
            }
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        private bool IsValid(string username, string password)
        {
            bool isValid = true;
            string errorString = "Please enter ";

            if (String.IsNullOrEmpty(username))
            {
                errorString += "username ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(password))
            {
                errorString += "password ";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }
    }
}
