using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }
      
        public int CategoryId { get; set; }

        public int QuantityAvailable { get; set; }

        public string ImageUrl { get; set; }


        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public CategoryVM?  Category { get; set; }
    }
}
