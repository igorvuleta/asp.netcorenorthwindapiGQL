using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.CategoriesRepo;
using graphqldemo.Data.Repositories.SupplierRepo;
using graphqldemo.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Query
{
    public class NorthWindQuery : ObjectGraphType
    {
        public NorthWindQuery(ProductRepository productRepository, SupplierRepo supplierRepo, CategoriesRepo categoriesRepo)
        {
            Field<ListGraphType<ProductType>>("products",
                resolve: context => productRepository.GetAllAsync());

            Field<ListGraphType<SupplierType>>("suppliers",
                 resolve: context => supplierRepo.GetAllAsync());
            Field<ListGraphType<CategoriesType>>("categories",
                 resolve: context => categoriesRepo.GetAllAsync());

        }
    }
}
