
namespace BookStore.API.DTO
{
    public class Income
    {
        public int Page {get; set;}
        public int Size {get; set;}
        public int TotalPage {get; set;}
        public int TotalOrder {get; set;}
        public List<Thongke> Data {get; set;}
    }
}