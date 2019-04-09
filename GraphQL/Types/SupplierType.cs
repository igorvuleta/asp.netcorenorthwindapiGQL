using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class SupplierType : ObjectGraphType<Suppliers>
    {
        public SupplierType()
        {
            Field(t => t.SupplierId);
            Field(t => t.CompanyName);
            Field(t => t.ContactName);
            Field(t => t.ContactTitle);
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.Phone);
            Field(t => t.Fax);
            Field(t => t.HomePage);

        }

    }
}
