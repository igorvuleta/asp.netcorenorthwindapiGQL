using System;
using System.Collections.Generic;
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

        public async Task<IList<Categories>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        
    }
}
