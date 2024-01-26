
using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Mappers
{
    public class ProductMapper : MapperBase<Product, ProductVM>
    {
        private readonly CategoryMapper _categoryMapper;
        public ProductMapper(CategoryMapper categoryMapper)
        {

            _categoryMapper = categoryMapper;
        }



        public override Product MapFromDestinationToSource(ProductVM destinationEntity)
        {
            if (destinationEntity == null) return null;
            return new Product
            {
                Id = destinationEntity.Id,
                Name = destinationEntity.Name,
                Brand = destinationEntity.Brand,
                CategoryId = destinationEntity.CategoryId,
                Price = destinationEntity.Price,
                QuantityAvailable = destinationEntity.QuantityAvailable,
                Description = destinationEntity.Description,
                ImageUrl = destinationEntity.ImageUrl,

                CreatedAt = destinationEntity.CreatedAt,
                CreatedBy = destinationEntity.CreatedBy,
                UpdatedAt = destinationEntity.UpdatedAt,
                UpdatedBy = destinationEntity.UpdatedBy,


                Category = _categoryMapper.MapFromDestinationToSource(destinationEntity.Category)

            };
        }



        public override ProductVM MapFromSourceToDestination(Product sourceEntity)
        {
            if (sourceEntity == null) return null;
            return new ProductVM
            {
                Id = sourceEntity.Id,
                Name = sourceEntity.Name,
                Brand = sourceEntity.Brand,
                CategoryId = sourceEntity.CategoryId,
                Price = sourceEntity.Price,
                QuantityAvailable = sourceEntity.QuantityAvailable,
                Description = sourceEntity.Description,
                ImageUrl = sourceEntity.ImageUrl,
                CreatedAt = sourceEntity.CreatedAt,
                UpdatedAt = sourceEntity.UpdatedAt,
                Category = _categoryMapper.MapFromSourceToDestination(sourceEntity.Category)
            };
        }
    }
}
