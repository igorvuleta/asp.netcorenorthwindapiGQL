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
                
                arguments:  new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" },
                    new QueryArgument<StringGraphType>() { Name = "filter" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");



                    if (id != 0)
                    {
                        return productRepository.GetOneArgs(id);
                    }


                    var productName = context.GetArgument<string>("filter");
                    if (productName != null)
                    {
                        return productRepository.GetNames(productName);
                    }
                    return productRepository.GetOne(id);

                });
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
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" },
                    new QueryArgument<StringGraphType>() { Name = "filterCity" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");



                    if (id != 0)
                    {
                        return supplierRepo.GetOneArgs(id);
                    }


                    var cityName = context.GetArgument<string>("filterCity");
                    if (cityName != null)
                    {
                        return supplierRepo.GetCities(cityName);
                    }
                    return supplierRepo.GetOne(id);

                });
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
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id"},
                    new QueryArgument<StringGraphType>() { Name = "filter"}),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    if (id != 0)
                    {
                        return categoriesRepo.GetOneArgs(id);
                    }
                    

                    var categoryName = context.GetArgument<string>("filter");
                    if (categoryName != null)
                    {
                        return categoriesRepo.GetNames(categoryName);
                    }
                    return categoriesRepo.GetOne(id); ;
                });
            Field<ListGraphType<OrderDetailsType>, IEnumerable<OrderDetails>>()
                .Name("OrderDetails")
                .Description("This table holds all order details, and is in a relationship with the products!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllOrderDetails", () => orderdetailsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<OrderDetailsType>(
                "OrderDetail",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return orderdetailsrepo.GetOne(id);
                }
                );
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
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return ordersrepo.GetOne(id);
                }
                );
            Field<ShippersType>(
                "shipper",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return shippersrepo.GetOne(id);
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
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
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
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return employeesrepo.GetOne(id);
                }
                );
            
            Field<ListGraphType<TerritoriesType>, IEnumerable<Territories>>()
              .Name("Territories")
              .Description("Territories table holds the region and territories descriptions and it is realted to the region table!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllTerritories", () => territoriesrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<EmployeeTerritoriesType>(
               "EmployeeTerritory",
               arguments: new QueryArguments(new QueryArgument<IdGraphType>
               { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   return employeterritoriesRepo.GetOne(id);
               }
               );
            Field<TerritoriesType>(
                "Territory",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return territoriesrepo.GetOne(id);
                }
                );
            Field<ListGraphType<RegionType>>()
             .Name("Regions")
             .Description("this table is holds region descriptions and it is not related to any other table in the database!")
                .ResolveAsync(async ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllRegions", () => regionsrepo.GetAllAsync());
                    return await loader.LoadAsync();

                });
            Field<RegionType>(
                "Region",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return regionsrepo.GetOne(id);
                }
                );

        }
    }
}
