using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using PL.Models;

namespace PL.Controllers
{
    public class UserController
    { 
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public void CreateUser(UserViewModel userViewModel)
        {
            //try
            //{
                var userDTO = new UserDTO { 
                    UserName = userViewModel.UserName,
                    Email = userViewModel.Email,
                    Password = userViewModel.Password,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName
                };

                userService.CreateUser(userDTO);
                
            //} catch(Exception ex)
            //{
            //    throw new Exception();
            //}
        }

        public UserViewModel GetUserByUsername(string username)
        {
            UserViewModel userViewModel = new UserViewModel();
            try
            {
                UserDTO userDTO = userService.GetUserByUsername(username);
                userViewModel = new UserViewModel
                {
                    UserName = userDTO.UserName,
                    Password = userDTO.Password,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email
                };
            }
            catch (Exception ex)
            {

            }
            return userViewModel;
        }
    }
}
