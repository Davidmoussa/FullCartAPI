﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.ViewModels.User
{
    public class RegisterVM
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        public string Password  { get; set; }
        public string Address { get; set; }

    }
}
