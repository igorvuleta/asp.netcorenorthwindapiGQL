using GraphQL.Types;
using graphqldemo.Data.Repositories.EmployeesRepo;
using graphqldemo.Data.Repositories.TerritoriesRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class EmployeeTerritoriesType : ObjectGraphType<EmployeeTerritories>
    {
        public EmployeeTerritoriesType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.EmployeeId, type: typeof(IdGraphType));
            Field(t => t.TerritoryId);
            Field<EmployeesType>(
                name: "employee",
                resolve: context => contextServiceLocator.EmplyeesRepo.GetOne(context.Source.EmployeeId)
                );
            Field<TerritoriesType>(
                name:"Territory",
                resolve: context => contextServiceLocator.TerritoriesRepo.GetOne(context.Source.TerritoryId)

                );
        }
    }
}
