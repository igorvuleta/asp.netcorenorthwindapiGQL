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
        CategoriesType()
        {
            Field(t => t.CategoryId);
            Field(t => t.CategoryName);
            Field(t => t.Description);
            Field(t => t.Picture);

        }
    }
}
