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
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Query
{
    public class NorthWindQuery : ObjectGraphType
    {
        public NorthWindQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<ListGraphType<ProductType>, IEnumerable<Products>>()
                .Name("Products")
                .Description("This table holds all products and product properties in relatioship with order details and suppliers!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.ProductRepository.GetAllAsync();
                });
            Field<ProductType>(
                "product",

                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" },
                    new QueryArgument<IntGraphType>() { Name = "filter" }),

                resolve: context =>
                {
                    var CategoryID = context.GetArgument<int>("id");



                    if (CategoryID != 0)
                    {
                        return contextServiceLocator.ProductRepository.GetOne(CategoryID);
                    }


                    var id = context.GetArgument<int>("filter");
                    if (id != null)
                    {
                        return contextServiceLocator.ProductRepository.GetOne(id);
                    }
                    return contextServiceLocator.ProductRepository.GetOne(CategoryID);

                });
            Field<ListGraphType<SupplierType>, IEnumerable<Suppliers>>()
                 .Name("Suppliers")
                 .Description("This table holds all suppliers in a relationship with products!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.SupplierRepo.GetAllAsync();
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
                        return contextServiceLocator.SupplierRepo.GetOneArgs(id);
                    }


                    var cityName = context.GetArgument<string>("filterCity");
                    if (cityName != null)
                    {
                        return  contextServiceLocator.SupplierRepo.GetCities(cityName);
                    }
                    return contextServiceLocator.SupplierRepo.GetOne(id);

                });
            Field<ListGraphType<CategoriesType>, IEnumerable<Categories>>()
                .Name("Categories")
                .Description("This table holds all Categories and is in a relationship with products!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.CategoriesRepo.GetAllAsync();

                });
            Field<CategoriesType>(
                "Category",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" },
                    new QueryArgument<StringGraphType>() { Name = "filter" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    //if (id != 0)
                    //{
                    //    return categoriesRepo.GetOneArgs(id);
                    //}


                    //var categoryName = context.GetArgument<string>("filter");
                    //if (categoryName != null)
                    //{
                    //    return categoriesRepo.GetNames(categoryName);
                    //}
                    return contextServiceLocator.CategoriesRepo.GetOne(id); ;
                });
            Field<ListGraphType<OrderDetailsType>, IEnumerable<OrderDetails>>()
                .Name("OrderDetails")
                .Description("This table holds all order details, and is in a relationship with the products!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.OrderDetailsRepo.GetAllAsync();

                });
            Field<OrderDetailsType>(
                "OrderDetail",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.OrderDetailsRepo.GetOne(id);
                }
                );
            Field<ListGraphType<OrdersType>, IEnumerable<Orders>>()
                .Name("Orders")
                .Description("This table holds all orders and is in relationship with order details and customers tables!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.OrdersRepo.GetAllAsync();


                });
            Field<OrdersType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.OrdersRepo.GetOne(id);
                }
                );
            Field<ShippersType>(
                "shipper",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.ShippersRepo.GetOne(id);
                }
                );
            Field<ListGraphType<ShippersType>, IEnumerable<Shippers>>()
               .Name("Shippers")
               .Description("This table holds all shippers and is in none relationship to other tables!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.ShippersRepo.GetAllAsync();


                });
            Field<ListGraphType<CustomersType>, IEnumerable<Customers>>()
                .Name("Customers")
                .Description("This table holds all Customers records and its not related to any other tables!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.CustomersRepo.GetAllAsync();


                });
            Field<CustomersType>(
                "Customer",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return contextServiceLocator.CustomersRepo.GetOne(id);
                }


                );
            Field<ListGraphType<CustomerCustomerDemoType>, IEnumerable<CustomerCustomerDemo>>()
               .Name("CustomersDemo")
               .Description("This table holds customer Id and customer type Id its related to the customers!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.CustomerCustomerDemoRepo.GetAllAsync();


                });
            Field<ListGraphType<CustomerDemographicsType>, IEnumerable<CustomerDemographics>>()
               .Name("CustomerDemographics")
               .Description("This table holds customer description and customer type id itßs related to the cutomer demo type!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.CustomerDemographicsRepo.GetAllAsync();


                });
            Field<ListGraphType<EmployeesType>, IEnumerable<Employees>>()
               .Name("Employees")
               .Description("This table holds all records about employees and its not related to any other table!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.EmplyeesRepo.GetAllAsync();

                });
            Field<EmployeesType>(
                "Employee",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.EmplyeesRepo.GetOne(id);
                }
                );

            Field<ListGraphType<TerritoriesType>, IEnumerable<Territories>>()
              .Name("Territories")
              .Description("Territories table holds the region and territories descriptions and it is realted to the region table!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.TerritoriesRepo.GetAllAsync();

                });
            Field<EmployeeTerritoriesType>(
               "EmployeeTerritory",
               arguments: new QueryArguments(new QueryArgument<IdGraphType>
               { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   return contextServiceLocator.EmployeeTerritoriesRepo.GetOneArgs(id);
               }
               );
            Field<TerritoriesType>(
                "Territory",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return contextServiceLocator.TerritoriesRepo.GetOne(id);
                }
                );
            Field<ListGraphType<RegionType>>()
             .Name("Regions")
             .Description("this table is holds region descriptions and it is not related to any other table in the database!")
                .ResolveAsync(async ctx =>
                {
                    return await contextServiceLocator.RegionRepo.GetAllAsync();

                });
            Field<RegionType>(
                "Region",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.RegionRepo.GetOne(id);
                }
                );


        }
    }
}
