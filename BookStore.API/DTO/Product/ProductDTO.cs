using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Product
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public int IdCate { get; set; }
    }
}
