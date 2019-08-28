using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.OrderDetailsRepo
{
    public class OrderDetailsRepo : IOrderDetailsRepo
    {
    //    private readonly NorthWindContext _dbContext;

    //    public OrderDetailsRepo(NorthWindContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public async Task<IList<OrderDetails>> GetAllAsync()
    //    {
    //        return await _dbContext.OrderDetails.ToListAsync();
    //    }
    //    public async Task<IList<OrderDetails>> GetOrder(int id)
    //    {
    //        return await _dbContext.OrderDetails.Where(o => o.OrderId.Equals(id)).ToListAsync();
    //    }
    //    public async Task<IList<OrderDetails>> GetAllAsyncList(int id)
    //    {
    //        return await _dbContext.OrderDetails.Where(p =>p.ProductId.Equals(id)).ToListAsync();
    //    }

    //    public async Task<IEnumerable<OrderDetails>> GetOneFor(int id)
    //    {
    //        return await _dbContext.OrderDetails.Where(p => p.ProductId == id).ToListAsync();

    //    }
    //    public async Task<IEnumerable<OrderDetails>> GetOneForOrders(int id)
    //    {
    //        return await _dbContext.OrderDetails.Where(p => p.OrderId == id).ToListAsync();
    //    }
    //    public async Task<OrderDetails> GetOne(int id)
    //    {
    //        return await _dbContext.OrderDetails.OrderBy(p => p.OrderId.Equals(id)).FirstOrDefaultAsync();
    //    }
    //    public async Task<OrderDetails> GetOneArgs(int? id)
    //    {
    //        return await _dbContext.OrderDetails.OrderBy(p => p.OrderId == id).FirstOrDefaultAsync();
    //    }
    //    public void RemoveEntry(OrderDetails orderDetails)
    //    {
    //        _dbContext.Remove(orderDetails);
    //        _dbContext.SaveChanges();
    //    }
    }
}
