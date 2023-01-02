using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private ApplicationContext db;
        public UserRepository(ApplicationContext context) 
        {
            this.db = context;
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public ICollection<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int id)
        {
            return db.Users.Find(id);
        }

        public void Update(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
