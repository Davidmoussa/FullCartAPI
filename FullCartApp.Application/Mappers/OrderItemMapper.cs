using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Mappers
{
    public class OrderItemMapper : MapperBase<OrderItem, OrderItemVM>
    {
        public override OrderItem MapFromDestinationToSource(OrderItemVM destinationEntity)
        {
           if (destinationEntity == null) { return null; }
            return new OrderItem
            {
                Id= destinationEntity.Id,   
                CategoryId= destinationEntity.CategoryId,
                Name= destinationEntity.Name,
                Price= destinationEntity.Price,
                OrderId= destinationEntity.OrderId,
                Quantity= destinationEntity.Quantity,
                ImageUrl= destinationEntity.ImageUrl,
                
                
            };
        }

        public override OrderItemVM MapFromSourceToDestination(OrderItem sourceEntity)
        {
            if (sourceEntity == null) { return null; }
            return new OrderItemVM
            {
                Id = sourceEntity.Id,
                CategoryId = sourceEntity.CategoryId,
                Name = sourceEntity.Name,
                Price = sourceEntity.Price,
                OrderId = sourceEntity.OrderId,
                Quantity = sourceEntity.Quantity,
                ImageUrl = sourceEntity.ImageUrl,


            };
        }
    }
}
