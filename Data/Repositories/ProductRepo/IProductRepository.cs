using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories
{
    interface IProductRepository
    {
        Task<IList<Products>> GetAllAsync();
    }
}
