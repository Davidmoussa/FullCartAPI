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
    public class ProductService : IProductService
    {
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _ProductRepository;
      
        private readonly ProductMapper _productMapper;
        public ProductService(
           IUnitOfWork unitOfWork, ProductMapper productMapper
            )
        {
            
            _unitOfWork = unitOfWork;
            _productMapper = productMapper;
            _ProductRepository = _unitOfWork.GetRepository<Product>();
        }
        public Response<ProductVM> AddOrUpdate(ProductVM model)
        {
            try
            {
                var product = _productMapper.MapFromDestinationToSource(model);

                if (product.Id == 0)
                {
                    _ProductRepository.Add(product);
                }
                else
                {
                    _ProductRepository.Update(product);
                }

                _unitOfWork.SaveChanges();
                model = _productMapper.MapFromSourceToDestination(product);

                return new Response<ProductVM>(ResponseStatus.Success, model);
            }
            catch (Exception ex)
            {

                return new Response<ProductVM>(ResponseStatus.Error, ex.Message, null);
            }
        }

        public Response<bool> Delete(int Id )
        {
            try
            {
                var result = _ProductRepository.FirstOrDefault(i => i.Id == Id);
                if (result == null)
                {
                    return new Response<bool>(ResponseStatus.Error, false);
                }

                result.IsDeleted = true;
                _ProductRepository.Update(result);
                _unitOfWork.SaveChanges();
                return new Response<bool>(ResponseStatus.Success, true);

            }
            catch (Exception e)
            {
                return new Response<bool>(ResponseStatus.Error, e.Message, false);
            }
        }

        public Response<List<ProductVM>> GetAll()
        {
            var result = _ProductRepository.GetAll().Where(i => i.IsDeleted == false).Select(i => _productMapper.MapFromSourceToDestination(i)).ToList();
            return new Response<List<ProductVM>>(ResponseStatus.Success, result);
        }

        public Response<ProductVM> GetById(int Id)
        {
            var product = _ProductRepository.FirstOrDefault(i => i.Id == Id) ;
            if (product == null)
            {
                return new Response<ProductVM>(ResponseStatus.Error, null);
            }
            var result = _productMapper.MapFromSourceToDestination(product);
            return new Response<ProductVM>(ResponseStatus.Success, result);
        }
    }
}
