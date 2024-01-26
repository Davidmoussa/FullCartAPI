
using FullCartApp.Application.Contracts.Helper;
using FullCartApp.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.Contracts
{
    public  interface ICategoryService
    {

        Response<CategoryVM> AddOrUpdate(CategoryVM model);
        Response<CategoryVM> GetById(int Id);
        Response<List<CategoryVM>> GetAll();
        Response<bool> Delete(int Id);

    }
}
