using BookStoreAPI.DTO.User;

namespace BookStoreAPI.DTO
{
    public class ViewBag
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public UserDTO data {get; set;}
    }
}
