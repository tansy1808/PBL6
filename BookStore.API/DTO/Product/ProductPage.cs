namespace BookStore.API.DTO.Product
{
    public class ProductPage
    {
        public int Size { get; set; }
        public int TotalPage { get; set; }
        public int Page { get; set; }
        public List<ProductView> data { get; set; }
    }
}
