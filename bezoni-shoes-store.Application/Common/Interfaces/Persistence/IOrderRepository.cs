﻿using bezoni_shoes_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);

        Task RemoveOrder(Guid orderId);

        Task<Order?> GetOrder(Guid orderId);

        Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId);
    }
}
