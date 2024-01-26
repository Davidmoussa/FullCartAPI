using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Core.Aggregates
{
    public class Category: BassEntity<int>
    {
    

        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public ICollection<Product> Product { get; set; }


    }
}
