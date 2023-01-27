using System;
using BLL.DTO;
using BLL.Interfaces;
using PL.Models;

namespace PL.Presenters
{
    public class UserController
    { 
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public UserModel CreateUser(UserModel userModel)
        {
            try
            {
                var userDTO = MapperPresenter.UserModelToDTOMapper.Map<UserDTO>(userModel);
                userService.CreateUser(userDTO);
                return userModel;

            } catch(Exception ex)
            {
                return null;
            }
        }
    }
}
