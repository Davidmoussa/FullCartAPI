using FullCartApp.Application.Contracts.Constants;
using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.Helper;
using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Application.Contracts.ViewModels.User;
using FullCartApp.Application.Mappers;
using FullCartApp.Core.Aggregates;
using FullCartApp.Core.Aggregates.User;
using FullCartApp.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FullCartApp.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Profile> _ProfileRepository;
        private readonly ProfleMapper _profleMapper;


        public AccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration , IUnitOfWork unitOfWork ,ProfleMapper profleMapper)
        {
            _userManager=userManager;
            _roleManager=roleManager;
            _configuration = configuration;
            _unitOfWork=unitOfWork;
            _ProfileRepository= _unitOfWork.GetRepository<Profile>();
            _profleMapper=profleMapper;
        }

        public  string GenerateJwtToken(IdentityUser user)
        {
            var claim = new[] {
                        new Claim("Id", user.Id),
                        new Claim("Rola",_userManager.GetRolesAsync(user).Result.FirstOrDefault())
                    };

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInHouer"]);

            var token = new JwtSecurityToken(
                   claims: claim,
              issuer: _configuration["Jwt:Site"],
              audience: _configuration["Jwt:Site"],
              expires: DateTime.UtcNow.AddHours(expiryInMinutes),
              signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString =  tokenHandler.WriteToken(token);
            return tokenString;

        }

        public async Task<Response<ProfileVM>> LoginAsync(LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null) return new Response<ProfileVM>(ResponseStatus.Error,null);
            if ( await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = GenerateJwtToken(user);

                var profile = _ProfileRepository.FirstOrDefault(i => i.UserId == user.Id);
                var profileVm = _profleMapper.MapFromSourceToDestination(profile)??new ProfileVM();
                profileVm.Token = token; 
                return   new Response<ProfileVM>(ResponseStatus.Success, profileVm); 
            }
            return   new Response<ProfileVM>(ResponseStatus.Error, null);
        }

        public async Task<Response<ProfileVM>> RegisterAsync(RegisterVM model)
        {
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    var newUser = new IdentityUser()
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };
                     await _userManager.CreateAsync(newUser, model.Email);

                    await _userManager.AddToRoleAsync(newUser, RoleConstant.User);
                    var profile = new Profile
                    {
                        Name = model.Name,
                        UserId = newUser.Id,
                        Address = model.Address,
                    };

                    _ProfileRepository.Add(profile);    
                    _unitOfWork.SaveChanges();
                    var profileVm= _profleMapper.MapFromSourceToDestination(profile);
                    profileVm.Token = GenerateJwtToken(newUser);
                    return new Response<ProfileVM>(ResponseStatus.Success, profileVm);
                }
                else
                {
                    return new Response<ProfileVM>(ResponseStatus.Error, "-", null); 
                }
               
            }
            catch (Exception e)
            {
                return new Response<ProfileVM>(ResponseStatus.Error,e.Message, null);
            }
           


        }
    }
}
