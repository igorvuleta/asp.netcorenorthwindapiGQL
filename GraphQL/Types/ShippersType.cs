using GraphQL.Types;
using graphqldemo.Data.Repositories.OrdersRepo;
using graphqldemo.Data.Repositories.ShippersRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class ShippersType : ObjectGraphType<Shippers>
    {
        public ShippersType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.ShipperId, type:typeof(IdGraphType));
            Field(t => t.CompanyName);
            Field(t => t.Phone);
            Field<ListGraphType<OrdersType>>(
                name:"orders",
                resolve: context => contextServiceLocator.OrdersRepo.GetAllAsync(context.Source.ShipperId)
                );

        
        }
    }
}
