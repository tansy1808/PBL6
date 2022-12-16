using BookStore.API.Data.Enities.Order;

namespace BookStore.API.DTOs.Views
{
    public class OrderViewDTOs:OrderProduct
    {
        public int IdOrder { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
        public DateTime DateOrder { get; set; }
        public List<OrderProduct> orders { get; set; }
    }
}
