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

        }
        public async Task<IList<Employees>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
