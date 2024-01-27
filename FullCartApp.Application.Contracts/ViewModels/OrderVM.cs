using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public decimal Totalprice { get; set; }
        public int Status { get; set; }
        public string userId { get; set; }
        public string Address { get; set; }
        public ICollection<OrderItemVM> OrderItems { get; set; }
    }
}
