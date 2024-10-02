using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public Task AddOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrderDetail(Guid orderDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
