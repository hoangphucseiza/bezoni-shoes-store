﻿using Mapster;

namespace bezoni_shoes_store.Server.Common.Mapping
{
    public class ProductMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<AddProductRequest, AddProductCommand>()
            //    .Map(dest => dest.CategoryID, src => src.CategoryID);

        }
    }
}
