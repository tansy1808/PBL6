namespace BookStoreAPI.DTO
{
    public class OrderProductAPI
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public string NameProduct {get; set;}
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
