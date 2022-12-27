namespace BookStore.API.DTO.Store
{
    public class ViewDTO
    {
        public int Page {get; set;}
        public int Size {get; set;}
        public int TotalPage {get; set;}
        public List<ViewOrderAll> Data {get; set;}
    }
}