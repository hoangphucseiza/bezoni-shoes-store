using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        public Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
