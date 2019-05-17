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
            return await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
        public async Task<Products> AddProduct(Products product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<int> RemoveProducts(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            _dbContext.Remove(product);
            return id;


            
        }
        public async Task<Products> getProductById(Products productId)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.ProductId.Equals(productId));
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

        public void  RemoveProduct(Products product)
        {
            _dbContext.Remove(product);
            _dbContext.SaveChanges();
        }

        public async Task<Products> GetOne(int id)
        {
            
            Products product = await _dbContext.Products.LastOrDefaultAsync(p => p.ProductId == 26 );
            return product;
        }

        public async Task<Products> GetOneArgs(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id );

        }
        public async Task<Products> GetNames(string productName)
        {
            return await _dbContext.Products.Where(p => p.ProductName.StartsWith(productName)).FirstOrDefaultAsync();
            


        }
        public async Task<IEnumerable<Products>> GetOneFor(string productName)
        {
            return await _dbContext.Products.Where(p => p.ProductName.StartsWith(productName)).ToListAsync();
        }
    }
        
}
