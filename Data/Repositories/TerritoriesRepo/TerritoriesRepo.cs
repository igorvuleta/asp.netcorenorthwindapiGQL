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
        public async Task<IList<Territories>> GetAllAsync(int regionId)
        {
            return await _dbContext.Territories.ToListAsync();
        }
        public async Task<IList<Territories>> GetAllAsync()
        {
            return await _dbContext.Territories.ToListAsync();
        }

        public async Task<Territories> GetOne(string id)
        {
            return await _dbContext.Territories.OrderBy(t => t.TerritoryId == id).FirstOrDefaultAsync();
        }
        public async Task<Territories> GetOne(int id)
        {
            return await _dbContext.Territories.OrderBy(t => t.RegionId == id).FirstOrDefaultAsync();
        }
    }
}
