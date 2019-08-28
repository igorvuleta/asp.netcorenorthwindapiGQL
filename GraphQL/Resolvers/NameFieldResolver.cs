using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Resolvers
{
    public class NameFieldResolver : IFieldResolver
    {
        public object Resolve(ResolveFieldContext context)
        {
            var source = context.Source;

            if (source == null)
            {
                return null;

            }

            var name = Char.ToUpperInvariant(context.FieldAst.Name[0]) + context.FieldAst.Name.Substring(1);
            var value = GetPropValue(source, name);

            value = value != null ? value : string.Empty;

            return value;
        }

        private static object GetPropValue(object source, string propName)
        {
            return source.GetType().GetProperty(propName).GetValue(source, null);
        }
    }
}
