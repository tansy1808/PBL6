using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.Views
{
    public class ProductViewDTOs
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public int Feedback { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal Discount { get; set; }
        public string Cate { get; set; }
    }
}
