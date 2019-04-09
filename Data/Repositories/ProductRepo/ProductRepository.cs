using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthWindContext _dbContext;

        public ProductRepository(NorthWindContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IList<Products>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
