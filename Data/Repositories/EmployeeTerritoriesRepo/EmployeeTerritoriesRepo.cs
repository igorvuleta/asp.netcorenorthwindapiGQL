using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.EmployeeTerritoriesRepo
{
    public class EmployeeTerritoriesRepo : IEmployeeTerritoriesRepo
    {
        private readonly NorthWindContext _dbContext;

        public EmployeeTerritoriesRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<EmployeeTerritories>> GetAllAsync(ICollection<EmployeeTerritories> employeeTerritories)
        {
            return await _dbContext.EmployeeTerritories.ToListAsync();
        }
        public async Task<IList<EmployeeTerritories>> GetAllAsync(string territoryId)
        {
            return await _dbContext.EmployeeTerritories.ToListAsync();
        }

        public async Task<IList<EmployeeTerritories>> GetAllAsync()
        {
            return await _dbContext.EmployeeTerritories.ToListAsync();
        }

        public async Task<IList<EmployeeTerritories>> GetAllAsyncArgs(string territoryId)
        {
            return await _dbContext.EmployeeTerritories.Where(et => et.TerritoryId.Equals(territoryId)).ToListAsync();
        }

        public async Task<IList<EmployeeTerritories>> GetOneArgs(int id)

        {
            
            return await _dbContext.EmployeeTerritories.Where(et => et.EmployeeId.Equals(id)).ToListAsync();
        }

        public Task<IList<EmployeeTerritories>> GetOneArgs(string id)
        {
            throw new NotImplementedException();
        }
    }
}
