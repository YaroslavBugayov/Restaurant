using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject;
using PL.Models;
using PL.Views;
using System;
using System.Windows.Forms;

namespace PL.Presenters
{
    internal class RegistrationPresenter
    {
        private RegistrationView view;
        private static IUserService userService;

        public RegistrationPresenter(RegistrationView view)
        {
            this.view = view;
            IKernel ninjectKernel = new StandardKernel(new NinjectDependenciesModule());
            userService = ninjectKernel.Get<IUserService>();

            this.view.RegistrationEvent += Register;
            this.view.Show();
        }

        public void Register(object sender, EventArgs e)
        {
            UserModel userModel = new UserModel()
            {
                UserName = view.Username,
                Password = view.Password,
                Email = view.Email,
                FirstName = view.FirstName,
                LastName = view.LastName
            };

            if (IsValid(userModel))
            {
                try
                {
                    var userDTO = MapperPresenter.UserModelToDTOMapper.Map<UserDTO>(userModel);
                    userService.CreateUser(userDTO);
                }
                catch (Exception ex) 
                {
                    return;
                }
                AuthorizedUserPresenter.Set(userModel);
                view.Close();
            }
        }

        private bool IsValid(UserModel userModel)
        {
            bool isValid = true;
            string errorString = "Please enter ";
            if (String.IsNullOrEmpty(userModel.UserName))
            {
                errorString += "username ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(userModel.Password))
            {
                errorString += "password ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(userModel.Email))
            {
                errorString += "email ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(userModel.FirstName))
            {
                errorString += "first name ";
                isValid = false;
            }
            if (String.IsNullOrEmpty(userModel.LastName))
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
