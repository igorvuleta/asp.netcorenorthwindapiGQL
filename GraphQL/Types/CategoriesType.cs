using GraphQL.Types;
using graphqldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphqldemo.GraphQL.Types
{
    public class CategoriesType : ObjectGraphType<Categories>
    {
        public CategoriesType()
        {
            Field(t => t.CategoryId, type:typeof(IdGraphType));
            Field(t => t.CategoryName);
            Field(t => t.Description);
           Field(t => t.Picture, type:typeof(ListGraphType<StringGraphType>));

        }
    }
}
