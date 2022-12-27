using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTO.Store
{
    public class MethodPayDTO
    {
        [Required]
        public string TypeName {get; set;}
    }
}