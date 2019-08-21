using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.OrdersRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class OrderDetailsType : ObjectGraphType<OrderDetails>
    {
    public OrderDetailsType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.OrderId);
            Field(t => t.ProductId, type:typeof(IdGraphType));
            Field(t => t.UnitPrice);
            Field(t => t.Quantity, type:typeof(IntGraphType));
            Field(t => t.Discount);
            Field<OrdersType>(
                name: "Order",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),



                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.OrdersRepo.GetOne(context.Source.OrderId);
                }
                
                );
            Field<ProductType>(
                name:"Product",
                resolve: context => contextServiceLocator.ProductRepository.GetOne(context.Source.ProductId)
                );
        }
    }
}
