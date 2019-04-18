using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthWindContext _dbContext;

        public ProductRepository(NorthWindContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IList<Products>> GetAllAsync(int categoryId)
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Products> AddProduct(Products product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IList<Products>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ILookup<int, Products>> GetProductsByIdAsync(IEnumerable<int> productsIds)
        {
            var products = await _dbContext.Products.Where(i => productsIds.Contains(i.ProductId)).ToListAsync();
            return products.ToLookup(r => r.ProductId);
        }

        public async Task<Products> GetOne(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
    }
        
}
