using FullCartApp.Application.Contracts.Helper;
using FullCartApp.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.Contracts
{
    public interface IOrderService
    {
        Response<OrderVM> AddOrUpdate(OrderVM model);
        Response<OrderVM> GetById(int Id);
        Response<List<OrderVM>> GetAll();
        Response<bool> Delete(int Id);
    }
}
