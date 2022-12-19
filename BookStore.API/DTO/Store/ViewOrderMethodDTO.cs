using BookStore.API.Data.Enities.Order;

namespace BookStore.API.DTO.Store
{
    public class ViewProductMethodDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public MethodPay data { get; set; }
    }
}
