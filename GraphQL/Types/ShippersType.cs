using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class ShippersType : ObjectGraphType<Shippers>
    {
        public ShippersType()
        {
            Field(t => t.ShipperId);
            Field(t => t.CompanyName);
            Field(t => t.Phone);
        }
    }
}
