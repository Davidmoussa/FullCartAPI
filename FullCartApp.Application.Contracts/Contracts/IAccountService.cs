using FullCartApp.Application.Contracts.Helper;
using FullCartApp.Application.Contracts.ViewModels.User;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.Contracts
{
    public interface IAccountService
    {
        Task<Response<ProfileVM>> LoginAsync(LoginVM model);
        Task<Response<ProfileVM>> RegisterAsync(RegisterVM model);
        string GenerateJwtToken(IdentityUser user);

    }
}
