using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using graphqldemo.Models;
using Microsoft.EntityFrameworkCore;

namespace graphqldemo.Data.Repositories.SupplierRepo
{
    public class SupplierRepo : ISupllierRepo
    {

        private readonly NorthWindContext _dbContext;

        public SupplierRepo(NorthWindContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IList<Suppliers>> GetAllAsync(int? supplierId)
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task<IList<Suppliers>> GetAllAsync()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task<ILookup<int, Suppliers>> GetAllId(IEnumerable<int> supplierIds )
        {
            var suppliers = await _dbContext.Suppliers.Where(sp => supplierIds.Contains(sp.SupplierId)).ToListAsync();
            return suppliers.ToLookup(r => r.SupplierId);
        }

        public async Task<Suppliers>  GetOne(int? id)
        {
            var getFirst = await _dbContext.Suppliers.SingleAsync(s => s.SupplierId == id);

            return getFirst;
            
            //return await _dbContext.Suppliers.FirstOrDefaultAsync(p => p.SupplierId == id);
        }
    }
}  

