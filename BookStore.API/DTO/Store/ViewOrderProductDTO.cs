using BookStore.API.Data.Enities.Order;

namespace BookStore.API.DTO.Store
{
    public class ViewOrderProductDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public OrderProduct data { get; set; }
    }
}
