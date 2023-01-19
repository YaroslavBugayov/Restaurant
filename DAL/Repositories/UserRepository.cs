using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private ApplicationContext db;
        private DbSet<User> test; 
        public UserRepository(ApplicationContext context) 
        {
            db = context;
            test = db.Set<User>();
        }

        public void Create(User user)
        {
            test.Add(user);
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

        public User GetByLogin(string username)
        {
            return db.Users.Find(username);
        }

        public void Update(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
