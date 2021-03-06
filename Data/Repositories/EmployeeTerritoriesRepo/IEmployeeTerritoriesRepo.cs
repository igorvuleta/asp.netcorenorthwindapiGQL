﻿using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.EmployeeTerritoriesRepo
{
    public interface IEmployeeTerritoriesRepo
    {
        Task<IList<EmployeeTerritories>> GetAllAsync(string territoryId);
        Task<IList<EmployeeTerritories>> GetAllAsync();
        Task<IList<EmployeeTerritories>> GetOneArgs(string id);
     
    }
}
