using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DATA.Enities.Product
{
    public class ProductCate
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MaxLength(256)]
        public string CategoryType {get; set;}
        public List<Products> products {get; set;}
    }
}