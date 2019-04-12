using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.CustomersRepo
{
    public interface ICustomersRepo
    {
        Task<IList<Customers>> GetAllAsync();
    }
}
