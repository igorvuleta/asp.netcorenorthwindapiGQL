using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class EmployeeTerritoriesType : ObjectGraphType<EmployeeTerritories>
    {
        public EmployeeTerritoriesType()
        {
            Field(t => t.EmployeeId, type: typeof(IdGraphType));
            Field(t => t.TerritoryId);
        }
    }
}
