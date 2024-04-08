namespace FiveSimApi.Dto
{
    public class GetPricesByProductIdResult
    {
        public string ProductId { get; set; }
        public List<ProductItemInfo> ProductItems { get; set; }

        public GetPricesByProductIdResult(string productId, List<ProductItemInfo> items)
        {
            ProductId = productId;
            ProductItems = items;
        }

        public class ProductItemInfo
        {
            public required string Country { get; set; }
            public required string OperatorId { get; set; }
            public double Cost { get; set; }
            public int Count { get; set; }
            public double Rate { get; set; }
        }
    }
}
