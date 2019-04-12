﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.ShippersRepo
{
    public class ShippersRepo : IShippersRepo
    {
        private readonly NorthWindContext _dbContext;

        public ShippersRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<Shippers>> GetAllAsync()
        {
            return await _dbContext.Shippers.ToListAsync();
        }
    }
}
