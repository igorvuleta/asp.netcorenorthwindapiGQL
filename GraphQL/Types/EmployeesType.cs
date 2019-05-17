using GraphQL.Types;
using graphqldemo.Data.Repositories.EmployeeTerritoriesRepo;
using graphqldemo.Data.Repositories.OrdersRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class EmployeesType : ObjectGraphType<Employees>
    {
        public EmployeesType(OrdersRepo ordersRepo, EmployeeTerritoriesRepo employeeTerritoriesRepo)
        {
            Field(t => t.EmployeeId, type:typeof(IdGraphType));
            Field(t => t.LastName);
            Field(t => t.FirstName);
            Field(t => t.Title);
            Field(t => t.TitleOfCourtesy);
            Field(t => t.BirthDate, type:typeof(DateGraphType));
            Field(t => t.HireDate, type: typeof(DateGraphType));
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.HomePhone);
            Field(t => t.Extension);
            Field(t => t.Photo, type:typeof(StringGraphType));
            Field(t => t.Notes);
            Field(t => t.ReportsTo, type:typeof(IntGraphType));
            Field(t => t.PhotoPath);
            Field<ListGraphType<OrdersType>>(
                name: "OrdersList",
                resolve: context => ordersRepo.GetAllAsync(context.Source.Orders)
                );
            Field<ListGraphType<EmployeeTerritoriesType>>(
                name: "Employeeteritories",
                resolve: context => employeeTerritoriesRepo.GetOne(context.Source.EmployeeId));
        }
    }
}
