
namespace BookStoreAPI.DTO.Store
{
    public class View
    {
        public int Page {get; set;}
        public int Size {get; set;}
        public int TotalPage {get; set;}
        public List<OrderView> Data {get; set;}
    }
}