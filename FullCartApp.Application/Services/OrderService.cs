using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.Helper;
using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Application.Mappers;
using FullCartApp.Core.Aggregates;
using FullCartApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Services
{
    public class OrderService : IOrderService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly OrderMapper _OrderMapper;
        private readonly IRepository<Order> _OrderRepository;
        public OrderService(IUnitOfWork unitOfWork,
                               OrderMapper OrderMapper)
        {

            _unitOfWork = unitOfWork;
            _OrderMapper = OrderMapper;
            _OrderRepository = _unitOfWork.GetRepository<Order>();
        }

        public Response<OrderVM> AddOrUpdate(OrderVM model)
        {
            try
            {
                var order = _OrderMapper.MapFromDestinationToSource(model);

                if (order.Id == 0)
                {
                    _OrderRepository.Add(order);
                }
                else
                {
                    _OrderRepository.Update(order);
                }

                _unitOfWork.SaveChanges();
                model = _OrderMapper.MapFromSourceToDestination(order);

                return new Response<OrderVM>(ResponseStatus.Success, model);
            }
            catch (Exception ex)
            {

                return new Response<OrderVM>(ResponseStatus.Error, ex.Message, null);
            }
        }

        public Response<bool> Delete(int Id)
        {
            try{
                var order = _OrderRepository.FirstOrDefault(i => i.Id == Id);
                if (order == null)
                {
                    return new Response<bool>(ResponseStatus.Error, false);
                }

                order.IsDeleted = true;
                _OrderRepository.Update(order);
                _unitOfWork.SaveChanges();
                return new Response<bool>(ResponseStatus.Success, true);

            }
            catch (Exception e)
            {
                return new Response<bool>(ResponseStatus.Error, e.Message, false);
            }
        }

        public Response<List<OrderVM>> GetAll()
        {
            var result = _OrderRepository.GetAll().Where(i => i.IsDeleted == false).Select(i => _OrderMapper.MapFromSourceToDestination(i)).ToList();
            return new Response<List<OrderVM>>(ResponseStatus.Success, result);
        }

        public Response<OrderVM> GetById(int Id)
        {
            var order = _OrderRepository.FirstOrDefault(i => i.Id == Id);
            if (order == null)
            {
                return new Response<OrderVM>(ResponseStatus.Error, null);
            }
            var result = _OrderMapper.MapFromSourceToDestination(order);
            return new Response<OrderVM>(ResponseStatus.Success, result);
        }
    }
}
