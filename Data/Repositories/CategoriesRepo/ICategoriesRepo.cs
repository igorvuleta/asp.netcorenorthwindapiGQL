using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.CategoriesRepo
{
    public interface ICategoriesRepo
    {
        Task<IList<Categories>> GetAllAsync();
        Task<Categories> GetOne(int id);
        Task<IList<Products>> GetAllAsync2(int id);
    }
}
