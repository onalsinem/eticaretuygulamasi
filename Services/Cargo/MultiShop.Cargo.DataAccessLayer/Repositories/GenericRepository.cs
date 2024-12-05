using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        void IGenericDal<T>.Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            if (values != null)
            {
                _context.Set<T>().Remove(values); 
                _context.SaveChanges();
            }
        }


        List<T> IGenericDal<T>.GetAll()
        {
            var values=_context.Set<T>().ToList();
            return values;
        }

        T IGenericDal<T>.GetById(int id)
        {
            var values = _context.Set<T>().Find(id);
            return values;
        }

        void IGenericDal<T>.Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        void IGenericDal<T>.Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
