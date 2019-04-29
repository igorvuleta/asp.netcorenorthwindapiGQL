using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.OrdersRepo
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly NorthWindContext _dbContext;

        public OrdersRepo(NorthWindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<Orders>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<Orders> GetOne(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
        }
    }
}
