using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositories
{
    public class PricelistRepository : IRepository<Pricelist>
    {
        private ApplicationContext db;
        public PricelistRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Pricelist pricelist)
        {
            db.Pricelists.Add(pricelist);
        }

        public void Delete(int id)
        {
            Pricelist pricelist = db.Pricelists.Find(id);
            if (pricelist != null)
            {
                db.Pricelists.Remove(pricelist);
            }
        }

        public ICollection<Pricelist> GetAll()
        {
            return db.Pricelists.ToList();
        }

        public Pricelist GetById(int id)
        {
            return db.Pricelists.Find(id);
        }

        public Pricelist GetByLogin(string username)
        {
            throw new NotImplementedException();
        }

        public void Update(Pricelist pricelist)
        {
            db.Entry(pricelist).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
