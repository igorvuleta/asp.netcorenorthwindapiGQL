﻿using System;
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

        public async Task<EmployeeTerritories> GetOne(string territoryId)
        {
            return await _dbContext.EmployeeTerritories.OrderBy(et => et.TerritoryId).FirstOrDefaultAsync();
        }


        //    public async Task<EmployeeTerritories> GetAllAsync()
        //    {
        //        return await _dbContext.EmployeeTerritories.ToListAsync();
        //    }
        //
    }
}
