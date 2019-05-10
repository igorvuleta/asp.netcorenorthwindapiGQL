using GraphQL.Types;
using graphqldemo.Data.Repositories.CustomerDemographicsRepo;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomerDemographicsType : ObjectGraphType<CustomerDemographics>
    {
        public CustomerDemographicsType(CustomerDemographicsRepo customerDemographicsRepo)
        {
            Field(t => t.CustomerTypeId, type: typeof(IdGraphType));
            Field(t => t.CustomerDesc);
            Field<ListGraphType<CustomerCustomerDemoType>>(
                name: "CustomerCustomerDemoList",

                resolve: context => customerDemographicsRepo.GetOne(context.Source.CustomerTypeId)
                );
        }
    }
}
