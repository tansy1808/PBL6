using BookStore.API.DTO.User;

namespace BookStore.API.DTO
{
    public class ViewBag
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public UserDTO data {get; set;}
    }
}
