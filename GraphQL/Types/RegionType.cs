using GraphQL.Types;
using graphqldemo.Data.Repositories.TerritoriesRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class RegionType : ObjectGraphType<Region>
    {
        public RegionType(TerritoriesRepo territoriesRepo)
        {
            Field(t => t.RegionId);
            Field(t => t.RegionDescription);
            Field<ListGraphType<TerritoriesType>>(
                name: "territoriesList",
                resolve: context => territoriesRepo.GetAllAsync(context.Source.RegionId)
                );
        }
    }
}
