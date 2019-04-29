using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.EmployeesRepo
{
    public class EmployeesRepo : IEmployeesRepo
    {
        private readonly NorthWindContext _dbContext;

        public EmployeesRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<Employees>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
        public async Task<Employees> GetOne(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(p => p.EmployeeId == id);
        }
    }
}
