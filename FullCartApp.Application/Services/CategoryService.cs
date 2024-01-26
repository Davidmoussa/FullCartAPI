
using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.Helper;
using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Application.Mappers;
using FullCartApp.Core.Aggregates;
using FullCartApp.Core.Contracts;



namespace FullCartApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryMapper _categoryMapper;
        private readonly IRepository<Category> _CategorytRepository;
        public CategoryService(IUnitOfWork unitOfWork,
                               CategoryMapper categoryMapper)
        {

            _unitOfWork = unitOfWork;
            _categoryMapper = categoryMapper;
            _CategorytRepository= _unitOfWork.GetRepository<Category>();
        }

        public Response<CategoryVM> AddOrUpdate(CategoryVM model)
        {
            try
            {
                var category = _categoryMapper.MapFromDestinationToSource(model);

                if (category.Id == 0)
                {
                    _CategorytRepository.Add(category);
                }
                else
                {
                    _CategorytRepository.Update(category);
                }

                _unitOfWork.SaveChanges();
                model = _categoryMapper.MapFromSourceToDestination(category);

                return new Response<CategoryVM>(ResponseStatus.Success, model);
            }
            catch (Exception ex)
            {

                return new Response<CategoryVM>(ResponseStatus.Error, ex.Message, null);
            }


        }

        public Response<bool> Delete(int Id)
        {
            try
            {
                var category = _CategorytRepository.Find(i => i.Id == Id).ToList().FirstOrDefault();
                if (category == null)
                {
                    return new Response<bool>(ResponseStatus.Error, false);
                }

                category.IsDeleted = true;
                _CategorytRepository.Update(category);
                _unitOfWork.SaveChanges();
                return new Response<bool>(ResponseStatus.Success, true);

            }
            catch (Exception e)
            {
                return new Response<bool>(ResponseStatus.Error, e.Message, false);
            }

        }

        public Response<List<CategoryVM>> GetAll()
        {
            var result = _CategorytRepository.GetAll().Where(i=>i.IsDeleted==false).Select(i=> _categoryMapper.MapFromSourceToDestination(i)).ToList();
            return new Response<List<CategoryVM>>(ResponseStatus.Success, result);
        }

        public Response<CategoryVM> GetById(int Id)
        {
            var category = _CategorytRepository.Find(i => i.Id == Id).ToList().FirstOrDefault();
            if (category == null)
            {
                return new Response<CategoryVM>(ResponseStatus.Error, null);
            }
            var result = _categoryMapper.MapFromSourceToDestination(category);
            return new Response<CategoryVM>(ResponseStatus.Success, result);
        }
     }



    }
