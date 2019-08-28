using GraphQL.Resolvers;
using GraphQL.Types;
using graphqldemo.Data;
using graphqldemo.Data.Models;
using graphqldemo.Helpers;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;


namespace graphqldemo.GraphQL.Resolvers
{
    public class MyFieldResolver : IFieldResolver
    {
        private TableMetadata _tableMetadata;
        private NorthWindContext _dbContext;

        public MyFieldResolver(TableMetadata tableMetadata, NorthWindContext dbContext)
        {
            _tableMetadata = tableMetadata;
            _dbContext = dbContext;
        }

        public object Resolve(ResolveFieldContext context)
        {
            var queryable = _dbContext.Query(_tableMetadata.AssemblyFullName);
            var splitter = context.SubFields.Keys;
            if (context.FieldName.Contains("_list"))
            {

                var first = context.Arguments["first"] != null ?
                    context.GetArgument("first", int.MaxValue) :
                    int.MaxValue;

                var offset = context.Arguments["offset"] != null ?
                    context.GetArgument("offset", 0) :
                    0;

                return queryable
                    .Skip(offset)
                    .Take(first)
                    .ToDynamicList<object>();
            }
            else
            {
                //var id = context.GetArgument<int>("id");
                return queryable;
                    //.FirstOrDefault($"Id == @0", id);
                
            };
        }
    }
}
