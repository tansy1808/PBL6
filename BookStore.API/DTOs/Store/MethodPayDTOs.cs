using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Store
{
    public class MethodPayDTOs
    {
        [Required]
        public string TypeName {get; set;}
    }
}