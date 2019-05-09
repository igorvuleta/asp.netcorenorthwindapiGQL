using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.CustomerDemographicsRepo
{
    public class CustomerDemographicsRepo : ICustomerDemographicsRepo
    {
        private readonly NorthWindContext _dbContext;

        public CustomerDemographicsRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<CustomerDemographics>> GetAllAsync()
        {
            return await _dbContext.CustomerDemographics.ToListAsync();
        }

        public async Task<CustomerDemographics> GetOne(string id)
        {
          return await _dbContext.CustomerDemographics.FirstOrDefaultAsync(p => p.CustomerTypeId == id);
        }
    }
}
