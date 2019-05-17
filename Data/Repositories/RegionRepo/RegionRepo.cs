using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.RegionRepo
{
    public class RegionRepo : IRegionRepo
    {
        private readonly NorthWindContext _dbContext;

        public RegionRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Region>> GetAllAsync()
        {
            return await _dbContext.Region.ToListAsync();
        }

        public async Task<Region> GetOne(int id)
        {
            return await _dbContext.Region.Where(r => r.RegionId == id).FirstOrDefaultAsync();
        }
    }
}
