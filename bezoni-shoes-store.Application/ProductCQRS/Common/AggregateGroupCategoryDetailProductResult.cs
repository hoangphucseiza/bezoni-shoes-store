using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Common
{
    public class AggregateGroupCategoryDetailProductResult
    {
        public string? IdCategory { get; set; }
        public int TotalProduct { get; set; }
        public decimal TotalPrice { get; set; }
    };
}
