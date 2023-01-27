using BLL.Infrastructure;
using BLL.Interfaces;
using Ninject;
using PL.Models;
using PL.Views;
using System;
using System.Windows.Forms;

namespace PL.Presenters
{
    internal class LoginPresenter
    {
        private LoginView view;
        private static IUserService userService;
        public LoginPresenter(LoginView view) 
        { 
            this.view = view;
            IKernel ninjectKernel = new StandardKernel(new NinjectBindings());
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
                userModel = MapperPresenter.UserDTOtoModelMapper.Map<UserModel>(userDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AuthorizedUserPresenter.Set(userModel);
            view.Close();
        }
    }

}
