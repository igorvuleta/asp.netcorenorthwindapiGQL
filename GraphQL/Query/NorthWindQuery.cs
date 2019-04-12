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
            EmployeeTerritoriesRepo employeterritoriesRepo, TerritoriesRepo territoriesrepo, RegionRepo regionrepo)
        {
            Field<ListGraphType<ProductType>>("products",
                resolve: context => productRepository.GetAllAsync());

            Field<ListGraphType<SupplierType>>("suppliers",
                 resolve: context => supplierRepo.GetAllAsync());
            Field<ListGraphType<CategoriesType>>("categories",
                 resolve: context => categoriesRepo.GetAllAsync());
            Field<ListGraphType<OrderDetailsType>>("OrderDetails",
                 resolve: context => orderdetailsrepo.GetAllAsync());
            Field<ListGraphType<OrdersType>>("Orders",
                resolve: context => ordersrepo.GetAllAsync());
            Field<ListGraphType<ShippersType>>("Shippers",
                resolve: context => shippersrepo.GetAllAsync());
            Field<ListGraphType<CustomersType>>("Customers",
                resolve: context => customersrepo.GetAllAsync());
            Field<ListGraphType<CustomerCustomerDemoType>>("CustomersDemo",
               resolve: context => customersrepo.GetAllAsync());
            Field<ListGraphType<CustomerDemographicsType>>("CustomerDemographics",
               resolve: context => customerdemographicsrepo.GetAllAsync());
            Field<ListGraphType<EmployeesType>>("Employees",
               resolve: context => employeesrepo.GetAllAsync());
            Field<ListGraphType<EmployeeTerritoriesType>>("EmployeesTerritories",
               resolve: context => employeesrepo.GetAllAsync());
            Field<ListGraphType<TerritoriesType>>("Territories",
              resolve: context => territoriesrepo.GetAllAsync());
           Field<ListGraphType<RegionType>>("Regions",
             resolve: context => regionrepo.GetAllAsync());

        }
    }
}
