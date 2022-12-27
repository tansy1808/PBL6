using BookStoreAPI.DATA.Enities.Order;

namespace BookStoreAPI.DTO.Store
{
    public class ViewOrderDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Orders data { get; set; }
    }
}
