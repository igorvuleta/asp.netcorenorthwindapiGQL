using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.RegionRepo
{
    public interface IRegionRepo
    {
        Task<IList<Region>> GetAllAsync();
        Task<Region> GetOne(int id);
    }
}
