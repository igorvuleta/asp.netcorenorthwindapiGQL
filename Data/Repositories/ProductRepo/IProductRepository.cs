using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IList<Products>> GetAllAsync();
        Task<Products> GetOne(int id);
        Task<IEnumerable<Products>> GetOneFor(string productName);
    }
}
