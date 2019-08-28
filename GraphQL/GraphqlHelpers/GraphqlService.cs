using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.GraphqlHelpers
{
    public class GraphqlService
    {
        public GraphqlService()
        {

        }

        public Dictionary<string, CollectionMetaData> Collections { get; private set; }
    }
}
