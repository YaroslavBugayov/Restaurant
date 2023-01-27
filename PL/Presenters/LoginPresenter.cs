﻿using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Ninject;
using PL.Models;
using PL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PL.Presenters
{
    internal class LoginPresenter
    {
        private LoginView view;
        private RestaurantView parentView;
        private static IUserService userService;
        public LoginPresenter(LoginView view, RestaurantView parentView) 
        { 
            this.view = view;
            this.parentView = parentView;
            IKernel ninjectKernel = new StandardKernel(new NinjectDependenciesModule());
            userService = ninjectKernel.Get<IUserService>();

            this.view.LoginEvent += Login;
            this.view.Show();
        }
        public void Login(object sender, EventArgs e)
        {
            UserModel userModel = new UserModel();
            try
            {
                var userDTO = userService.Authenticate(view.Username, view.Password);

                if (userDTO.Password != view.Password)
                {

                }

                userModel = MapperPresenter.UserDTOtoModelMapper.Map<UserModel>(userDTO);
            }
            catch (Exception ex)
            {
                
            }
            if (userModel != null)
            {
                AuthorizedUserController.Set(userModel);
                parentView.loggedIntoAccount();
                view.Close();
            }
            else
            {
                MessageBox.Show("Invalid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}