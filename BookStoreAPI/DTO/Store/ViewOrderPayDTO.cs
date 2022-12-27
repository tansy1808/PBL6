using BookStoreAPI.DATA.Enities.Order;

namespace BookStoreAPI.DTO.Store
{
    public class ViewOrderPayDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Payment data { get; set; }
    }
}
