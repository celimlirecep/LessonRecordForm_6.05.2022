using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

       

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetSingle(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           
            _context.Entry(entity).State=EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
