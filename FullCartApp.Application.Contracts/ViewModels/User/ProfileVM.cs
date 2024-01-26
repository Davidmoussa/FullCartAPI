using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.ViewModels.User
{
    public class ProfileVM
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
