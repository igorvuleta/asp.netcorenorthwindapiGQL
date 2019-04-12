using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class OrderDetailsType : ObjectGraphType<OrderDetails>
    {
    public OrderDetailsType()
        {
            Field(t => t.OrderId);
            Field(t => t.ProductId, type:typeof(ProductType));
            Field(t => t.UnitPrice);
            Field(t => t.Quantity, type:typeof(IntGraphType));
            Field(t => t.Discount);
        }
    }
}
