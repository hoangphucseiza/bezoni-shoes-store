﻿using bezoni_shoes_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IOrderDetailRepository
    {
        Task AddOrderDetail(OrderDetail orderDetail);
        Task RemoveOrderDetail(Guid orderDetailId);
    }
}