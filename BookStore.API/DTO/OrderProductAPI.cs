namespace BookStore.API.DTO
{
    public class OrderProductAPI
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
