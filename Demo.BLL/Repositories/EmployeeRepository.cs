using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
       // private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext ):base(dbContext)
        {
           //_dbContext = dbContext;

        }
        public IQueryable<Employee> GetEmployeeByAdrress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address.ToLower().Contains(address.ToLower()));
        }

        public IQueryable<Employee> SearchEmployeeByName(string name)
            => _dbContext.Employees.Include(E=>E.Department).Where(E => E.Name.ToLower().Contains(name));
    }
}
