using PL.Presenters;
using PL.Models;
using BLL.Interfaces;
using System;
using System.Windows.Forms;
using Ninject;
using Ninject.Modules;
using BLL.Infrastructure;

namespace PL.Views
{
    public partial class RegistrationView : Form
    {
        private static IUserService userServise;
        private static UserController userController;
        private RestaurantView parentWindow;
        public RegistrationView(RestaurantView parentWindow)
        {
            InitializeComponent();
            NinjectModule dependencies = new NinjectDependenciesModule();
            IKernel ninjectKernel = new StandardKernel(dependencies);
            userServise = ninjectKernel.Get<IUserService>();
            userController = new UserController(userServise);
            this.parentWindow = parentWindow;
        }

        private void buttonSignUp2_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;

            UserModel userModel = new UserModel()
            {
                UserName = username,
                Password = password,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (IsValid(username, password, email, firstName, lastName))
            {
                var user = userController.CreateUser(userModel);
                if (user != null)
                {
                    AuthorizedUserController.Set(userModel);
                    parentWindow.loggedIntoAccount();
                    Close();
                }
            }
        }

        private void RegistrationView_Load(object sender, EventArgs e)
        {

        }

        private bool IsValid(string username, string password, string email, 
            string firsName, string lastName)
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
            if (String.IsNullOrEmpty(email))
            {
                errorString += "email ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(firsName))
            {
                errorString += "first name ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(lastName))
            {
                errorString += "last name ";
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
