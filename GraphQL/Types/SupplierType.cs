using GraphQL.DataLoader;
using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.SupplierRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class SupplierType : ObjectGraphType<Suppliers>
    {
        public SupplierType( SupplierRepo suppliersRepo, ProductRepository productRepository)
        {
            Field(t => t.SupplierId, nullable:false, type:typeof(IdGraphType));
            Field(t => t.CompanyName);
            Field(t => t.ContactName);
            Field(t => t.ContactTitle);
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region, nullable:true);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.Phone);
            Field(t => t.Fax, nullable:true);
            Field(t => t.HomePage, nullable:true);
            Field<ListGraphType<ProductType>>(
                "productList1",
                 arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" },
                    new QueryArgument<StringGraphType>() { Name = "filterName" } ),
                 resolve: context =>
                 {
                     var id = context.GetArgument<int>("id");
                     var productName = context.GetArgument<string>("productName");

                     if (productName != null)
                     {
                         return productRepository.GetOneFor(productName);
                     }


                     return suppliersRepo.GetAllAsync(context.Source.SupplierId);
                 }

                );

        }

    }
}
