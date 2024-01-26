using FullCartApp.Application.Contracts.ViewModels;

using FullCartApp.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Mappers
{
    public class CategoryMapper : MapperBase<Category, CategoryVM>
    {
       // private readonly ProductMapper _productMapper; 
        public CategoryMapper() {
          //  _productMapper = productMapper;
        }
    

        public override Category MapFromDestinationToSource(CategoryVM destinationEntity)
        {
            if (destinationEntity == null) return null;
            return new Category
            {
                Id = destinationEntity.Id,
                Name = destinationEntity.Name,
                ImageUrl = destinationEntity.ImageUrl,
                CreatedAt = destinationEntity.CreatedAt,
                CreatedBy = destinationEntity.CreatedBy,
                UpdatedAt = destinationEntity.UpdatedAt,
                UpdatedBy = destinationEntity.UpdatedBy,
              //  Product = _productMapper.MapFromDestinationToSource(destinationEntity.Product.ToList()) ,


            };
        }



        public override CategoryVM MapFromSourceToDestination(Category sourceEntity)
        {
            if (sourceEntity == null) return null;
            return new CategoryVM
            {
                Id = sourceEntity.Id,
                Name = sourceEntity.Name,
                ImageUrl = sourceEntity.ImageUrl,
                CreatedAt = sourceEntity.CreatedAt,
                CreatedBy = sourceEntity.CreatedBy,
                UpdatedAt = sourceEntity.UpdatedAt,
                UpdatedBy = sourceEntity.UpdatedBy,
               // Product = _productMapper.MapFromSourceToDestination(sourceEntity.Product.ToList()),
              
            };
        
         }
    }
}
