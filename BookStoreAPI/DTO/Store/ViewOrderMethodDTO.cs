using BookStoreAPI.DATA.Enities.Order;

namespace BookStoreAPI.DTO.Store
{
    public class ViewProductMethodDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public MethodPay data { get; set; }
    }
}
