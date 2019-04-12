using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.TerritoriesRepo
{
    public class TerritoriesRepo : ITerritoriesRepo
    {
        private readonly NorthWindContext _dbContext;
        public TerritoriesRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<Territories>> GetAllAsync()
        {
            return await _dbContext.Territories.ToListAsync();
        }
    }
}
