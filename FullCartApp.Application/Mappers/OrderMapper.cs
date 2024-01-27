using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Mappers
{
    public class OrderMapper : MapperBase<Order, OrderVM>
    {
        private readonly OrderItemMapper _orderItemMapper;
        public OrderMapper(OrderItemMapper orderItemMapper)
        {
            _orderItemMapper = orderItemMapper;
        }

        public override Order MapFromDestinationToSource(OrderVM destinationEntity)
        {
            if (destinationEntity == null) return null;
            return new Order
            {
                Id = destinationEntity.Id,
                Totalprice = destinationEntity.Totalprice,
                Address = destinationEntity.Address,
                userId = destinationEntity.userId,
                OrderItems= _orderItemMapper.MapFromDestinationToSource(destinationEntity.OrderItems.ToList())
            };
        }

        public override OrderVM MapFromSourceToDestination(Order sourceEntity)
        {
            if (sourceEntity == null) return null;
            return new OrderVM
            {
                Id = sourceEntity.Id,
                Totalprice = sourceEntity.Totalprice,
                Address = sourceEntity.Address,
                userId = sourceEntity.userId,
                OrderItems = _orderItemMapper.MapFromSourceToDestination(sourceEntity.OrderItems.ToList())
            };
        }
    }
}
