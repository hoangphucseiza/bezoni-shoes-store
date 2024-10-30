namespace bezoni_shoes_store.Application.AdminCQRS.Common
{
    public class GetAllProductResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Voucher { get; set; }

        public string CategoryName { get; set; }
    }
}
