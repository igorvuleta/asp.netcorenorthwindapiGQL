using GraphQL.DataLoader;
using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.CategoriesRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CategoriesType : ObjectGraphType<Categories>
    {
        public CategoriesType(  ProductRepository productRepository, CategoriesRepo categoriesRepo)
        {
            Field(t => t.CategoryId, type:typeof(IdGraphType));
            Field(t => t.CategoryName);
            Field(t => t.Description);
            Field(t => t.Picture, type:typeof(ListGraphType<StringGraphType>));
            Field<ProductType>(
                name: "product",
                arguments:new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id"},
                    new QueryArgument<StringGraphType>() { Name = "filterName"}
                    

                    ),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var productName = context.GetArgument<string>("filterName");
                    if (productName != null)
                    {
                        return productRepository.GetNames(productName);
                    }

                    return productRepository.GetOne(context.Source.CategoryId);



                });
           







        }
    }
}
