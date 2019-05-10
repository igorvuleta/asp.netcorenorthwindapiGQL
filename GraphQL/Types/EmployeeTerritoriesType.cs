using GraphQL.Types;
using graphqldemo.Data.Repositories.EmployeesRepo;
using graphqldemo.Data.Repositories.TerritoriesRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class EmployeeTerritoriesType : ObjectGraphType<EmployeeTerritories>
    {
        public EmployeeTerritoriesType(EmployeesRepo employeesRepo, TerritoriesRepo territoriesRepo)
        {
            Field(t => t.EmployeeId, type: typeof(IdGraphType));
            Field(t => t.TerritoryId);
            Field<EmployeesType>(
                name: "employee",
                resolve: context => employeesRepo.GetOne(context.Source.EmployeeId)
                );
            Field<TerritoriesType>(
                name:"Territory",
                resolve: context => territoriesRepo.GetOne(context.Source.TerritoryId)

                );
        }
    }
}
