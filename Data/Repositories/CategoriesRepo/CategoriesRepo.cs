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

        public async Task<Categories> GetOne(int id)
        {
            return await _dbContext.Categories.OrderBy(p => p.CategoryId == id).FirstAsync();
        }

        public async Task<Categories> GetNames(string categoryName)
        {
            Categories something = await _dbContext.Categories.Where(p => p.CategoryName == categoryName).FirstOrDefaultAsync();
            Console.WriteLine(something);
            return something;
           
            
        }
    }
}
