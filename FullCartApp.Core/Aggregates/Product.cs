using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FullCartApp.Core.Aggregates
{


    public class Product:BassEntity<int>
    {
     

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public int QuantityAvailable { get; set; }

        public string ImageUrl { get; set; }

       
 
        public Category Category { get; set; }



    }
}
