using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Product.Common
{
    public record AddProductResult(string Id, string Name, string Description, string Price, string Image);
}
