using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.ShippersRepo
{
    public interface IShippersRepo
    {
        Task<IList<Shippers>> GetAllAsync();
    }
}
