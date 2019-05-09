using GraphQL.Types;
using graphqldemo.Data.Repositories.CustomerDemographicsRepo;
using graphqldemo.Data.Repositories.CustomersRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomerCustomerDemoType : ObjectGraphType<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoType(CustomersRepo customersRepo, CustomerDemographicsRepo customerDemographicsRepo)
        {
            Field(t => t.CustomerId, type: typeof(IdGraphType));
            Field(t => t.CustomerTypeId, type:typeof(IdGraphType));
            Field<CustomersType>(
                name: "Customer",
                resolve: context => customersRepo.GetOne(context.Source.CustomerId));

            Field<CustomerDemographicsType>(
                name: "CustomerDemographic",
                resolve: context => customerDemographicsRepo.GetOne(context.Source.CustomerTypeId));
                   
        }
    }
}
