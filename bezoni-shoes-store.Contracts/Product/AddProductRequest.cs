﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Contracts.Product
{
    public record AddProductRequest( string Name, string Description, decimal Price, string Image, string CategoryID);
}
