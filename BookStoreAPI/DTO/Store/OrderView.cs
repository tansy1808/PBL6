namespace BookStoreAPI.DTO.Store
{
    public class OrderView
    {
        public int IdOrder { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string SDT {get; set;}
        public string TypePay {get; set;}
        public decimal Total { get; set; }
        public DateTime DateOrder { get; set; }
        public List<OrderProductAPI> orders { get; set; }
    }
}
