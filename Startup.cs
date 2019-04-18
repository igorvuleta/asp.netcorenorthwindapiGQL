using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using graphqldemo.Data;
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
using graphqldemo.GraphQL;
using graphqldemo.middleware;
using graphqldemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace graphqldemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins("http://localhost:4200", "https://localhost:44372")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<NorthWindContext>(options =>
            {
                options.UseSqlServer(Configuration["ApiConfiguration:DbConnectionString"]);
            });


            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<DataLoaderDocumentListener>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<SupplierRepo>();
            services.AddScoped<CategoriesRepo>();
            services.AddScoped<OrderDetailsRepo>();
            services.AddScoped<OrdersRepo>();
            services.AddScoped<CustomersRepo>();
            services.AddScoped<ShippersRepo>();
            services.AddScoped<EmployeesRepo>();
            services.AddScoped<RegionRepo>();
            services.AddScoped<EmployeeTerritoriesRepo>();
            services.AddScoped<TerritoriesRepo>();
            services.AddScoped<CustomerCustomerDemoRepo>();
            services.AddScoped<CustomerDemographicsRepo>();
            
            services.AddScoped<ISchema,NorthWindSchema>();

            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = true;

            }).AddGraphTypes(ServiceLifetime.Scoped).AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors("CorsPolicy");
            app.UseMiddleware<GraphqlMiddleware>();
            app.UseHttpsRedirection();
            app.UseGraphQL<NorthWindSchema>();
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());
            app.UseGraphQLPlayground( new GraphQLPlaygroundOptions());
            app.UseMvc();

        }
    }
}
