using GraphQL.DataLoader;
using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.CategoriesRepo;
using graphqldemo.Helpers;
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
        public CategoriesType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.CategoryId, type:typeof(IdGraphType));
            Field(t => t.CategoryName);
            Field(t => t.Description);
            Field(t => t.Picture, type:typeof(ListGraphType<StringGraphType>));
            Field<ListGraphType<ProductType>>(
                name: "productList",
                arguments:new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id"},
                    new QueryArgument<StringGraphType>() { Name = "filterName"}
                    

                    ),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    
                    return contextServiceLocator.CategoriesRepo.GetAllAsync2(context.Source.CategoryId);



                });
           







        }
    }
}
