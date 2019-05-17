using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.CategoriesRepo
{
    public class CategoriesRepo : ICategoriesRepo
    {

        private readonly NorthWindContext _dbContext;

        public CategoriesRepo(NorthWindContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IList<Products>> GetAllAsync2(int id)
        {
            var products = await _dbContext.Products.Where(p => p.CategoryId.Equals(id)).ToListAsync();
            return products;
        }

        public async Task<IList<Categories>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Categories> GetOne(int id)
        {
            
            Categories categories = await _dbContext.Categories.Where(c => c.CategoryId.Equals(id)).FirstOrDefaultAsync();
            return categories;
        }
        
        
        public async Task<Categories> GetOneArgs(int id)
        {
            return await _dbContext.Categories.Where(p => p.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<Categories> GetNames(string categoryName)
        {
           return await _dbContext.Categories.Where(p => p.CategoryName.StartsWith(categoryName)).FirstOrDefaultAsync();
            
        }
    }
}
