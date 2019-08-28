using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.GraphqlHelpers
{
    public class Field
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; } 
        public FieldBaseType BaseType { get; set; }
        public JObject Options { get; set; }
    }
}
