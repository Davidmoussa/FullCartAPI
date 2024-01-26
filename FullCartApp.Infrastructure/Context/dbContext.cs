using FullCartApp.Core.Aggregates;
using FullCartApp.Core.Aggregates.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Infrastructure.Context
{
    public class dbContext: IdentityDbContext
    {
        public dbContext(DbContextOptions<dbContext> options): base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Profile> Profile { get; set; }

    }
}
