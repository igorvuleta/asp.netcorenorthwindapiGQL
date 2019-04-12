using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomerDemographicsType : ObjectGraphType<CustomerDemographics>
    {
        public CustomerDemographicsType()
        {
            Field(t => t.CustomerTypeId, type: typeof(CustomerCustomerDemoType));
            Field(t => t.CustomerDesc);
        }
    }
}
