namespace BookStore.API.DTOs.Views
{
    public class ProductPageDTOs
    {
        public int Size { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public List<ProductViewDTOs> Views { get; set; }
    }
}
