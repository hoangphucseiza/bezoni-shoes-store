namespace bezoni_shoes_store.Application.AdminCQRS.Common
{
    public class ItemResult
    {

        public string id { get; set; }
        public string categoryName { get; set; }
        public string productName { get; set; }
        public string itemName { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public int? quantity { get; set; }
        public decimal? price { get; set; }
        public int? voucher { get; set; }

    }
}
