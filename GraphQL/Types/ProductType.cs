using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.CategoriesRepo;
using graphqldemo.Data.Repositories.OrderDetailsRepo;
using graphqldemo.Data.Repositories.SupplierRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Products>
    {
        public ProductType(CategoriesRepo categoriesRepo, SupplierRepo suppliersRepo, OrderDetailsRepo orderDetailsRepo, ProductRepository productRepository)
        {
            Field(t => t.ProductId, nullable: false, type: typeof(IdGraphType));
            Field(t => t.ProductName).Description("Product name");
            Field(t => t.UnitPrice, nullable: true);
            Field(t => t.UnitsInStock, type: typeof(IntGraphType));
            Field(t => t.UnitsOnOrder, type: typeof(IntGraphType));
            Field(t => t.QuantityPerUnit);
            Field(t => t.CategoryId, type: typeof(IntGraphType));
            Field(t => t.Discontinued);
            Field(t => t.ReorderLevel, type: typeof(IntGraphType));
            Field(t => t.SupplierId, type: typeof(IdGraphType));

            Field<SupplierType>(
                name: "Supplier",

                resolve: context => suppliersRepo.GetOne(context.Source.ProductId));
            Field<ListGraphType<OrderDetailsType>>(
                 "orderList",
                 arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "productId" }),
                 resolve: context =>
                 {
                     var id = context.GetArgument<int>("productId");

                     


                     return orderDetailsRepo.GetAllAsyncList(context.Source.ProductId);
                 }
                
                );
                
                

                

        }
    }
}
