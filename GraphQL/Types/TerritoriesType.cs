using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class TerritoriesType : ObjectGraphType<Territories>
    {
        public TerritoriesType()
        {
            Field(t => t.TerritoryId);
            Field(t => t.TerritoryDescription);
            Field(t => t.RegionId, type:typeof(IdGraphType));
        }
    }
}
