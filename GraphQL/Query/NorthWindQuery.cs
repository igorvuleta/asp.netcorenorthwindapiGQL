using GraphQL.DataLoader;
using GraphQL.Types;
using graphqldemo.Data.Repositories;
using graphqldemo.Data.Repositories.CategoriesRepo;
using graphqldemo.Data.Repositories.CustomerCustomerDemoRepo;
using graphqldemo.Data.Repositories.CustomerDemographicsRepo;
using graphqldemo.Data.Repositories.CustomersRepo;
using graphqldemo.Data.Repositories.EmployeesRepo;
using graphqldemo.Data.Repositories.EmployeeTerritoriesRepo;
using graphqldemo.Data.Repositories.OrderDetailsRepo;
using graphqldemo.Data.Repositories.OrdersRepo;
using graphqldemo.Data.Repositories.RegionRepo;
using graphqldemo.Data.Repositories.ShippersRepo;
using graphqldemo.Data.Repositories.SupplierRepo;
using graphqldemo.Data.Repositories.TerritoriesRepo;
using graphqldemo.GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Query
{
    public class NorthWindQuery : ObjectGraphType
    {
        public NorthWindQuery(ProductRepository productRepository, SupplierRepo supplierRepo, CategoriesRepo categoriesRepo,
            OrderDetailsRepo orderdetailsrepo, OrdersRepo ordersrepo, ShippersRepo shippersrepo, CustomersRepo customersrepo,
            CustomerCustomerDemoRepo customercustomerdemorepo, CustomerDemographicsRepo customerdemographicsrepo, EmployeesRepo employeesrepo,
            EmployeeTerritoriesRepo employeterritoriesRepo, TerritoriesRepo territoriesrepo, RegionRepo regionsrepo, IDataLoaderContextAccessor accessor)
        {
            Field<ListGraphType<ProductType>, IEnumerable<Products>>()
                .Name("Products")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllProducts", () => productRepository.GetAllAsync());
                    return await loader.LoadAsync();
                });
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                    { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetOne(id);
                }

                
                );
            Field<ListGraphType<SupplierType>, IEnumerable<Suppliers>>()
                 .Name("Suppliers")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllSuppliers", () => supplierRepo.GetAllAsync());
                    return await loader.LoadAsync();
                });

            Field<SupplierType>(
                "supplier",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return supplierRepo.GetOne(id);
                }
                );
            Field<ListGraphType<CategoriesType>, IEnumerable<Categories>>()
                .Name("Categories")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCategories", () => categoriesRepo.GetAllAsync());
                    return await loader.LoadAsync();
                });
            Field<CategoriesType>(
                "Category",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return categoriesRepo.GetOne(id);
                });


            Field<ListGraphType<OrderDetailsType>, IEnumerable<OrderDetails>>()
                .Name("OrderDetails")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllOrderDetails", () => orderdetailsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<OrdersType>, IEnumerable<Orders>>()
                .Name("Orders")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllOrders", () => ordersrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<ShippersType>, IEnumerable<Shippers>>()
               .Name("Shippers")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllShippers", () => shippersrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<CustomersType>, IEnumerable<Customers>>()
                .Name("Customers")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCustomers", () => customersrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<CustomerCustomerDemoType>, IEnumerable<CustomerCustomerDemo>>()
               .Name("CustomersDemo")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCustomersDemo", () => customercustomerdemorepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<CustomerDemographicsType>, IEnumerable<CustomerDemographics>>()
               .Name("CustomerDemographics")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCustomersDemographics", () => customerdemographicsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<EmployeesType>, IEnumerable<Employees>>()
               .Name("Employees")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllEmployees", () => employeesrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<EmployeeTerritoriesType>, IEnumerable<EmployeeTerritories>>()
               .Name("EmployeesTerritories")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllEmployeesTerritories", () => employeterritoriesRepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<TerritoriesType>, IEnumerable<Territories>>()
              .Name("Territories")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllTerritories", () => territoriesrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<RegionType>>()
             .Name("Regions")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllRegions", () => regionsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });

        }
    }
}
