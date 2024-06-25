using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly MVCAppDbContext _context;

        public GenericRepository(MVCAppDbContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public T Get(int id)
        => _context.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
