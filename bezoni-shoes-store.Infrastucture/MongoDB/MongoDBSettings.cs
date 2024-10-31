namespace bezoni_shoes_store.Infrastucture.MongoDB
{
    public class MongoDBSettings
    {
        public const string SectionName = "MongoDB";
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserCollectionName { get; set; }

        public string? ProductCollectionName { get; set; }

        public string? OrderCollectionName { get; set; }

        public string? OrderDetailCollectionName { get; set; }

        public string? RoleCollectionName { get; set; }

        public string? CategoryCollectionName { get; set; }

        public string? ItemCollectionName { get; set; }


    }
}
