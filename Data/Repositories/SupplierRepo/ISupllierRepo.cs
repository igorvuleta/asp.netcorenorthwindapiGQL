using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.SupplierRepo
{
    public interface ISupllierRepo
    {
        Task<IList<Suppliers>> GetAllAsync();
        Task<Suppliers> GetCities(string cityName);
        Task<Suppliers> GetOne(int? id);
        Task<Suppliers> GetOneArgs(int? id);
        Task<IList<Products>> GetAllAsync(int supplierId);

    }
}
