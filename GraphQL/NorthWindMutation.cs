using GraphQL;
using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.OrderDetailsRepo;
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
        public NorthWindMutation(ProductRepository productRepository, OrderDetailsRepo orderDetailsRepository)
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
            //FieldAsync<ProductType>(
            //    "deleteProduct",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
            //    resolve: async context =>
            //    {
            //        var id =  context.GetArgument<int>("productId");
            //        var product = await productRepository.GetOne(id);
            //        var orderDetails = await orderDetailsRepository.GetOne(id);

            //        if (product == null)
            //        {
            //            context.Errors.Add(new ExecutionError("no product in db"));
            //            return null;
            //        }
            //        productRepository.RemoveProduct(product);
            //        orderDetailsRepository.RemoveEntry(orderDetails);


            //        return "the product was deleted";


                   
            //    });
        }
    }
}
