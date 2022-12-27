using BookStore.API.Data.Enities.Order;

namespace BookStore.API.DTO.Store
{
    public class ViewOrderDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Orders data { get; set; }
    }
}
