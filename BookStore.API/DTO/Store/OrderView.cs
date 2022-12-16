

namespace BookStore.API.DTO.Store
{
    public class OrderView
    {
        public int IdOrder { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
        public DateTime DateOrder { get; set; }
        public List<OrderProductAPI> orders { get; set; }
    }
}
