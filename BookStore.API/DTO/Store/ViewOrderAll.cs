namespace BookStore.API.DTO.Store
{
    public class ViewOrderAll
    {
        public int IdOrder { get; set; }
        public string NameUser {get; set;}
        public string Address { get; set; }
        public string Status { get; set; }
        public string SDT {get; set;}
        public string TypePay {get; set;}
        public decimal Total { get; set; }
        public DateTime DateOrder { get; set; }
    }
}