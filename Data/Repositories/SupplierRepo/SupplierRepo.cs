using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.SupplierRepo
{
    public class SupplierRepo : ISupllierRepo
    {

        private readonly NorthWindContext _dbContext;

        public SupplierRepo(NorthWindContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IList<Suppliers>> GetAllAsync()
        {
            return await _dbContext.Suppliers.ToListAsync();

        }

       
    }  
}
