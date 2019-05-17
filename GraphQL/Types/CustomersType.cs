using GraphQL.Types;
using graphqldemo.Data.Repositories.CustomerCustomerDemoRepo;
using graphqldemo.Data.Repositories.OrdersRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomersType : ObjectGraphType<Customers>
    {
        public CustomersType(CustomerCustomerDemoRepo customercustomerDemoRepo, OrdersRepo ordersRepo)
        {
            Field(t => t.CustomerId, type:typeof(IdGraphType));
            Field(t => t.CompanyName);
            Field(t => t.ContactName);
            Field(t => t.ContactTitle);
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region, nullable: true);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.Phone);
            Field(t => t.Fax, nullable:true);
            Field<ListGraphType<CustomerCustomerDemoType>>(
                name: "CustomerCustomerDemoList",

                resolve: context => customercustomerDemoRepo.GetOne(context.Source.CustomerId));
            Field<ListGraphType<OrdersType>>(
                "orderList",
                 arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "orderId" }),


                resolve: context =>


                 {
                     var id = context.GetArgument<string>("orderId");

                     


                     return ordersRepo.GetAllAsync(context.Source.CustomerId);
                 });
                
        }
    }
}
