using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Core.Aggregates
{
    public class Order : BassEntity<int>
    {

        public decimal Totalprice { get; set; }
        public int Status { get; set; }
        public string userId  { get; set; }
        public string Address  { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
