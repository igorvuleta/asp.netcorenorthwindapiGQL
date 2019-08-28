using GraphQL.Types;
using graphqldemo.Data.Repositories.CustomersRepo;
using graphqldemo.Data.Repositories.EmployeesRepo;
using graphqldemo.Data.Repositories.OrderDetailsRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class OrdersType : ObjectGraphType<Orders>
    {



        public OrdersType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.OrderId);
            Field(t => t.CustomerId, type:typeof(IdGraphType));
            Field(t => t.EmployeeId, type:typeof(IdGraphType));
            Field(t => t.OrderDate, type:typeof(DateGraphType));
            Field(t => t.RequiredDate, type: typeof(DateGraphType));
            Field(t => t.ShippedDate, type: typeof(DateGraphType));
            Field(t => t.ShipVia, type:typeof(IntGraphType));
            Field(t => t.Freight, type: typeof(DecimalGraphType));
            Field(t => t.ShipName);
            Field(t => t.ShipAddress);
            Field(t => t.ShipCity);
            Field(t => t.ShipRegion);
            Field(t => t.ShipPostalCode);
            Field(t => t.ShipCountry);
            //Field<ListGraphType<OrderDetailsType>>(
            //     "orderDetailList",
            //     arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "orderId" }),
            //     resolve: context =>
            //     {
            //         var id = context.GetArgument<int>("orderId");

            //         if (id != 0)
            //         {
            //             return contextServiceLocator.OrderDetailsRepo.GetOneForOrders(id);
            //         }


            //         return contextServiceLocator.OrderDetailsRepo.GetOrder(context.Source.OrderId);
            //     }

            //    );
            Field<CustomersType>(
                name: "Customer",
                resolve: context => contextServiceLocator.CustomersRepo.GetOne(context.Source.CustomerId)
                );
            Field<EmployeesType>(
                name: "employee",
                resolve: context => contextServiceLocator.EmplyeesRepo.GetOne(context.Source.EmployeeId)
                );

        }
            
    }
}
