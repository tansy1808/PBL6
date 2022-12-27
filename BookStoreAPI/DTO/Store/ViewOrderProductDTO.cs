using BookStoreAPI.DATA.Enities.Order;

namespace BookStoreAPI.DTO.Store
{
    public class ViewOrderProductDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public OrderProduct data { get; set; }
    }
}
