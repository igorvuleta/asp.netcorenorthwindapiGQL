using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.CustomersRepo
{
    public class CustomersRepo : ICustomersRepo
    {
        private readonly NorthWindContext _dbContext;

        public CustomersRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Customers>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customers> GetOne(string id)
        {
            return await _dbContext.Customers.OrderBy(p => p.CustomerId == id).FirstOrDefaultAsync();
        }
    }
}
