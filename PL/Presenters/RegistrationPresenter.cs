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
            IKernel ninjectKernel = new StandardKernel(new NinjectBindings());
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

            try
            {
                var userDTO = MapperPresenter.UserModelToDTOMapper.Map<UserDTO>(userModel);
                userService.CreateUser(userDTO);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
 
            userModel.Id = userService.GetUserByUsername(userModel.UserName).Id;

            AuthorizedUserPresenter.Set(userModel);
            view.Close();
        }
    }
}
