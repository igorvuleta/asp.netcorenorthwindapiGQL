using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.GraphqlHelpers
{
    public class CollectionMetaData
    {
        public string CollectionName { get; set; }
        public bool AllowNonMappedFields { get; set; }

        public List<Field> FieldSettings { get; set; } = new List<Field>(); 
    }
}
