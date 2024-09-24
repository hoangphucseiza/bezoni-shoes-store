using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.MongoDB
{
    public class MongoDBSettings
    {
        public const string SectionName = "MongoDB";
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserCollectionName { get; set; }

    }
}
