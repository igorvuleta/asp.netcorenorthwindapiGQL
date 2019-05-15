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

        public async Task<IList<Categories>> GetAllAsync(int productId)
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<IList<Categories>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Categories> GetOne(int CategoryID)
        {
            

            Categories categories = await _dbContext.Categories.Where(c => c.CategoryId.Equals(CategoryID)).FirstOrDefaultAsync();
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
