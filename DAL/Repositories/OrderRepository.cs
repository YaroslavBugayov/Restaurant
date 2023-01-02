using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {
        private ApplicationContext db;
        public OrderRepository(ApplicationContext context) 
        {
            this.db = context;
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
            }
        }

        public ICollection<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return db.Orders.Find(id);
        }
    }
}
