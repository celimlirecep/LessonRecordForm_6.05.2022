using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBaseRepository<T> where T:class,new()
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        List<T> GetAll();
        T GetSingle(int id);

    }
}
