using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Store
{
    public class MethodPayDTO
    {
        [Required]
        public string TypeName {get; set;}
    }
}