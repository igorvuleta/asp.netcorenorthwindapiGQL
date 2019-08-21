using GraphQL.Types;
using graphqldemo.Data.Repositories.TerritoriesRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class RegionType : ObjectGraphType<Region>
    {
        public RegionType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.RegionId);
            Field(t => t.RegionDescription);
            Field<ListGraphType<TerritoriesType>>(
                name: "territoriesList",
                resolve: context => contextServiceLocator.TerritoriesRepo.GetAllAsync(context.Source.RegionId)
                );
        }
    }
}
