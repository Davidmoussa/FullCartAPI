
using FullCartApp.Application.Contracts.Constants;
using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Mappers;
using FullCartApp.Application.Services;
using FullCartApp.Core.Contracts;
using FullCartApp.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.CompositionRoot
{
    public class ServiceProvider
    {
        public static IServiceCollection BuildServiceProvider(IConfiguration configuration, IServiceCollection services)
        {
            RegisterServices(services);
            RegisterPersistence(configuration, services);
            RegisterUtilities(services);
            LoadExternalDependencies(configuration, services);
            return services;
        }

        public static async Task MigrateDBAsync(IConfiguration configuration, IServiceProvider  services)
        {
            var context = services.GetService<dbContext>();
             context.Database.Migrate();


            var userManager = services.GetService<UserManager<IdentityUser>>();
            var roleManager = services.GetService<RoleManager<IdentityRole>>();



            // Create  Role  Admin 
            var adminRoleExist = await roleManager.RoleExistsAsync(RoleConstant.Admin);
            if (!adminRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = RoleConstant.Admin
                });
            }

            // Create  Role  User 
            var UserRoleExist = await roleManager.RoleExistsAsync(RoleConstant.User);
            if (!UserRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = RoleConstant.User
                });
            }

            var AdminEmail = configuration["AdminUser:Email"];
            var adminUser = await userManager.FindByNameAsync(AdminEmail);
            if (adminUser == null)
            {
                var newAdminUser = new IdentityUser()
                {
                    UserName = AdminEmail,
                    Email = AdminEmail


                };

                await userManager.CreateAsync(newAdminUser, configuration["AdminUser:Password"]);

                await userManager.AddToRoleAsync(newAdminUser, RoleConstant.Admin);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(adminUser, RoleConstant.Admin)))
                {
                    await userManager.AddToRoleAsync(adminUser, RoleConstant.Admin);
                }
            }



        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IAccountService,AccountService>();
        }

        private static void RegisterPersistence(IConfiguration configuration, IServiceCollection services)
        {
            var dbConnectionString = configuration.GetConnectionString("dafualtConnection");

            services.AddDbContext<dbContext>(opt => opt.UseSqlServer(dbConnectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();


        }

        private static void RegisterUtilities(IServiceCollection services)
        {
            services.AddScoped<ProductMapper>();
            services.AddScoped<CategoryMapper>();
            services.AddScoped<ProfleMapper>();


        }
        private static void LoadExternalDependencies(IConfiguration configuration, IServiceCollection services)
        {

           
        }
    }
}