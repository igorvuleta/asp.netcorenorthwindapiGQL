using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Data.Repositories.TerritoriesRepo
{
    public interface ITerritoriesRepo
    {
        Task<IList<Territories>> GetAllAsync(int regionId);
        Task<Territories> GetOne(string id);
        Task<IEnumerable<Territories>> GetAllAsync();
    }
}
