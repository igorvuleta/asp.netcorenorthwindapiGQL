using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.SupplierRepo
{
    interface ISupllierRepo
    {
        Task<IList<Suppliers>> GetAllAsync();

    }
}
