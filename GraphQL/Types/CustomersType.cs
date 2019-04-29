using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CustomersType : ObjectGraphType<Customers>
    {
        public CustomersType()
        {
            Field(t => t.CustomerId, type:typeof(IdGraphType));
            Field(t => t.CompanyName);
            Field(t => t.ContactName);
            Field(t => t.ContactTitle);
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region, nullable: true);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.Phone);
            Field(t => t.Fax, nullable:true);

        }
    }
}
