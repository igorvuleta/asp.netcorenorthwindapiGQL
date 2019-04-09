using GraphQL;
using GraphQL.Types;
using graphqldemo.GraphQL.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL
{
    public class NorthWindSchema : Schema
    {
        public NorthWindSchema(IDependencyResolver resolver ) : base(resolver)
        {
            Query = resolver.Resolve<NorthWindQuery>();
        }
    }
}
