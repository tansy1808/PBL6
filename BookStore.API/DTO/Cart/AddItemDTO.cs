namespace BookStore.API.DTO.Cart
{
    public class AddItemDTO
    {
        public int IdProduct { get; set; }
        public int IdCart { get; set; }
        public int Quantity { get; set; }
    }
}
