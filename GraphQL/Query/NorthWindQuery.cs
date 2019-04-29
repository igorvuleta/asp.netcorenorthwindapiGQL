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
                .Description("This table holds all products and product properties in relatioship with order details and suppliers!")
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
                 .Description("This table holds all suppliers in a relationship with products!")
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
                .Description("This table holds all Categories and is in a relationship with products!")
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
                .Description("This table holds all order details, and is in a relationship with the products!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllOrderDetails", () => orderdetailsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<OrdersType>, IEnumerable<Orders>>()
                .Name("Orders")
                .Description("This table holds all orders and is in relationship with order details and customers tables!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllOrders", () => ordersrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<OrdersType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return ordersrepo.GetOne(id);
                }
                );
            Field<ListGraphType<ShippersType>, IEnumerable<Shippers>>()
               .Name("Shippers")
               .Description("This table holds all shippers and is in none relationship to other tables!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllShippers", () => shippersrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<CustomersType>, IEnumerable<Customers>>()
                .Name("Customers")
                .Description("This table holds all Customers records and its not related to any other tables!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCustomers", () => customersrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<CustomersType>(
                "Customer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return customersrepo.GetOne(id);
                }


                );
            Field<ListGraphType<CustomerCustomerDemoType>, IEnumerable<CustomerCustomerDemo>>()
               .Name("CustomersDemo")
               .Description("This table holds customer Id and customer type Id its related to the customers!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCustomersDemo", () => customercustomerdemorepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<CustomerDemographicsType>, IEnumerable<CustomerDemographics>>()
               .Name("CustomerDemographics")
               .Description("This table holds customer description and customer type id itßs related to the cutomer demo type!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllCustomersDemographics", () => customerdemographicsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<EmployeesType>, IEnumerable<Employees>>()
               .Name("Employees")
               .Description("This table holds all records about employees and its not related to any other table!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllEmployees", () => employeesrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<EmployeesType>(
                "Employee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return employeesrepo.GetOne(id);
                }
                );
            Field<ListGraphType<EmployeeTerritoriesType>, IEnumerable<EmployeeTerritories>>()
               .Name("EmployeesTerritories")
               .Description("This table holds employee territories and it is related to the employee table!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllEmployeesTerritories", () => employeterritoriesRepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<TerritoriesType>, IEnumerable<Territories>>()
              .Name("Territories")
              .Description("Territories table holds the region and territories descriptions and it is realted to the region table!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllTerritories", () => territoriesrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<ListGraphType<RegionType>>()
             .Name("Regions")
             .Description("this table is holds region descriptions and it is not related to any other table in the database!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllRegions", () => regionsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });

        }
    }
}
