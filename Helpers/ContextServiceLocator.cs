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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.Helpers
{
    public class ContextServiceLocator
    {
        public IProductRepository ProductRepository => 
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IProductRepository>();

        public ISupllierRepo SupplierRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ISupllierRepo>();

        public ICategoriesRepo CategoriesRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ICategoriesRepo>();

        public ICustomerCustomerDemoRepo CustomerCustomerDemoRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ICustomerCustomerDemoRepo>();

        public ICustomerDemographicsRepo CustomerDemographicsRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ICustomerDemographicsRepo>();

        public ICustomersRepo CustomersRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ICustomersRepo>();

        public IEmployeesRepo EmplyeesRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IEmployeesRepo>();

        public IEmployeeTerritoriesRepo EmployeeTerritoriesRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IEmployeeTerritoriesRepo>();

        public IOrderDetailsRepo OrderDetailsRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IOrderDetailsRepo>();

        public IOrdersRepo OrdersRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IOrdersRepo>();

        public IRegionRepo RegionRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRegionRepo>();

        public IShippersRepo ShippersRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IShippersRepo>();

        public ITerritoriesRepo TerritoriesRepo =>
            _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ITerritoriesRepo>();
        

        public IHttpContextAccessor _httpContextAccessor { get; private set; }

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
