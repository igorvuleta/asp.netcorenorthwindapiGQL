using System;
using System.Collections.Generic;

namespace graphqldemo.Models
{
    public partial class Categories
    {
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
