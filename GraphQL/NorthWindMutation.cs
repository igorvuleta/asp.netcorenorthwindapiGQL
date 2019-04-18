using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.GraphQL.InputTypes;
using graphqldemo.GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL
{
    public class NorthWindMutation : ObjectGraphType
    {
        public NorthWindMutation(ProductRepository productRepository)
        {
            FieldAsync<ProductType>(
                "productInput",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
                    resolve: async context =>
                    {
                        var product = context.GetArgument<Products>("product");
                        return await context.TryAsyncResolve(
                            async c => await productRepository.AddProduct(product));
                    });
        }
    }
}
