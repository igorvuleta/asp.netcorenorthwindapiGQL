using GraphQL.Types;
using graphqldemo.Data.Repositories.CustomerDemographicsRepo;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomerDemographicsType : ObjectGraphType<CustomerDemographics>
    {
        public CustomerDemographicsType(ContextServiceLocator contextServiceLocator)
        {
            Field(t => t.CustomerTypeId, type: typeof(IdGraphType));
            Field(t => t.CustomerDesc);
            Field<ListGraphType<CustomerCustomerDemoType>>(
                name: "CustomerCustomerDemoList",

                resolve: context => contextServiceLocator.CustomerCustomerDemoRepo.GetOne(context.Source.CustomerTypeId)
                );
        }
    }
}
