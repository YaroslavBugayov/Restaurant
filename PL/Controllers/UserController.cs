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

        public UserViewModel CreateUser(UserViewModel userViewModel)
        {
            try
            {
                var userDTO = ViewModelToDTO(userViewModel);
                userService.CreateUser(userDTO);
                return userViewModel;

            } catch(Exception ex)
            {
                return null;
            }
        }

        public UserViewModel Authenticate(string username, string password) 
        { 
            UserViewModel userViewModel = new UserViewModel();
            try
            {
                var userDTO = userService.Authenticate(username, password);

                if (userDTO.Password != password) 
                {
                    
                }

                userViewModel = DTOtoViewModel(userDTO);
            } catch (Exception ex)
            {
                return null;
            }
            return userViewModel; 
        }

        public UserViewModel GetUserByUsername(string username)
        {
            UserViewModel userViewModel = new UserViewModel();
            try
            {
                UserDTO userDTO = userService.GetUserByUsername(username);
                userViewModel = DTOtoViewModel(userDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
            return userViewModel;
        }

        private UserViewModel DTOtoViewModel(UserDTO userDTO)
        {
            return new UserViewModel
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email
            };
        }

        private UserDTO ViewModelToDTO(UserViewModel userViewModel)
        {
            return new UserDTO
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName
            };
        }
    }
}
