using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class RegionType : ObjectGraphType<Region>
    {
        public RegionType()
        {
            Field(t => t.RegionId);
            Field(t => t.RegionDescription);
        }
    }
}
