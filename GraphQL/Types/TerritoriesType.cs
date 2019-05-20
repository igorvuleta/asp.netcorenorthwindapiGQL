using GraphQL.Types;
using graphqldemo.Data.Repositories.EmployeeTerritoriesRepo;
using graphqldemo.Data.Repositories.RegionRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class TerritoriesType : ObjectGraphType<Territories>
    {
        public TerritoriesType(RegionRepo regionRepo, EmployeeTerritoriesRepo employeeTerritoriesRepo)
        {
            Field(t => t.TerritoryId, type:typeof(IdGraphType));
            Field(t => t.TerritoryDescription);
            Field(t => t.RegionId, type:typeof(IdGraphType));
            Field<RegionType>(
                name:"Region",
                resolve: context => regionRepo.GetOne(context.Source.RegionId)
                );
            Field<ListGraphType<EmployeeTerritoriesType>>(
                "EmployeTerritoriesList",
                resolve: context => employeeTerritoriesRepo.GetAllAsyncArgs(context.Source.TerritoryId)
                );

        }
    }
}
