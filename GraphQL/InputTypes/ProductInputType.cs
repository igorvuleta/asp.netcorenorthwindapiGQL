using GraphQL.Types;
using graphqldemo.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.InputTypes
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "productInput";
            Field<NonNullGraphType<StringGraphType>>("productName");
            Field<DecimalGraphType>("unitPrice");
            Field<NonNullGraphType<StringGraphType>>("quantityPerUnit");
            Field<IntGraphType>("unitsInStock");
            Field<IntGraphType>("unitsOnOrder");
            Field<IntGraphType>("reorderLevel");
            Field<BooleanGraphType>("discontinued");
            Field<IntGraphType>("categoryId");

        }
    }
}
