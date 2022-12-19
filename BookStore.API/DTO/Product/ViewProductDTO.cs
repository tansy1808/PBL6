using BookStore.API.Data.Enities.Product;

namespace BookStore.API.DTO.Product
{
    public class ViewProductDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Products data { get; set; }
    }
}
