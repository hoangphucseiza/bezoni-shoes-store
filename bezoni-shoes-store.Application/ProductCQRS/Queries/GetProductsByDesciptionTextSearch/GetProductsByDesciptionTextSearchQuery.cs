using bezoni_shoes_store.Application.ProductCQRS.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductsByDesciptionTextSearch
{
    public record GetProductsByDesciptionTextSearchQuery(string Search) : IRequest<GetAllProductsResult>;
   
}
