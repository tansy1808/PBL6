
namespace BookStoreAPI.DTO.Store
{
    public class ViewOrders
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public OrdersViewDTO data { get; set; }
        
    }
}