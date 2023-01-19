using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T GetByLogin(string username);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
