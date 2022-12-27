using BookStoreAPI.DTO.User;

namespace BookStoreAPI.DTO
{
    public class MemberAPI
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPage { get; set; }
        public List<UserDTO> data { get; set; }
        
    }
}