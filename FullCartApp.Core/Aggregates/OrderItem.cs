using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Core.Aggregates
{
    public class OrderItem : BassEntity<int>
    {
        public string Name  { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
        public Order Order { get; set; }

        

    }
}
