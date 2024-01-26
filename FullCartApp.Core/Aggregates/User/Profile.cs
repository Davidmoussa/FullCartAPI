using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Core.Aggregates.User
{
    public class Profile : BassEntity<int>
    {


        public string Name { get; set; }
        public string Address { get; set; }

        public string UserId { get; set; }
     


    }
}
