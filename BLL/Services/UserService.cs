using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Services;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork unitOfWork) 
        {
            Database = unitOfWork;
        }
        public void Authenticate(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(UserDTO userDTO)
        {
            User user = new User()
            {
                Username = userDTO.UserName,
                Password = userDTO.Password,
                Email = userDTO.Email,
                FirstName= userDTO.FirstName,
                LastName= userDTO.LastName
            };

            Database.Users.Create(user);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByUsername(string username)
        {
            var user = Database.Users.GetByLogin(username);
            if (user != null) 
            {
                return MapperService.UserMapper.Map<UserDTO>(user);
            } else
            {
                throw new ValidationException("User does not exist");
            }
        }
    }
}
