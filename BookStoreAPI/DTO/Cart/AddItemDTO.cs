namespace BookStoreAPI.DTO.Cart
{
    public class AddItemDTO
    {
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
        public int Quantity { get; set; }
    }
}
