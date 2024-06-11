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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MVCAppDbContext _context;

        public EmployeeRepository(MVCAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Employee> SearchEmployeesByName(string name)
           => _context.Employees.Where(E => E.Name.Contains(name));

    }
}
