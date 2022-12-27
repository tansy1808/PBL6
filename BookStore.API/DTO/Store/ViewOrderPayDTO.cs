using BookStore.API.Data.Enities.Order;

namespace BookStore.API.DTO.Store
{
    public class ViewOrderPayDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Payment data { get; set; }
    }
}
