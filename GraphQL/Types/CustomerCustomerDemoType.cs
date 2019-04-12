using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomerCustomerDemoType : ObjectGraphType<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoType()
        {
            Field(t => t.CustomerId, type: typeof(CustomersType));
            Field(t => t.CustomerTypeId, type:typeof(IdGraphType));
        }
    }
}
