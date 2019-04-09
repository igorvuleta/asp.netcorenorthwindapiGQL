using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Products>
    {
        public ProductType()
        {
            Field(t => t.ProductId);
            Field(t => t.ProductName).Description("Product name");
            Field(t => t.UnitPrice, nullable: true);
            Field(t => t.QuantityPerUnit);
            Field(t => t.Discontinued);

        }
    }
}
