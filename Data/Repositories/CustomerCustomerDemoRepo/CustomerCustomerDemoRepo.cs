using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.CustomerCustomerDemoRepo
{
    public class CustomerCustomerDemoRepo : ICustomerCustomerDemoRepo
    {
        private readonly NorthWindContext _dbContext;

        public CustomerCustomerDemoRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<CustomerCustomerDemo>> GetAllAsync()
        {
            return await _dbContext.CustomerCustomerDemo.ToListAsync();
        }

        public async Task<CustomerCustomerDemo> GetOne(string CustomerId)
        {
            return await _dbContext.CustomerCustomerDemo.FirstOrDefaultAsync(s => s.CustomerId == CustomerId);
        }
    }
}
