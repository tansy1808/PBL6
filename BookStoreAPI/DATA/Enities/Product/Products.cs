using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DATA.Enities.Cart;
using BookStoreAPI.DATA.Enities.Order;

namespace BookStoreAPI.DATA.Enities.Product
{
    public class Products
    {
        [Key]
        public int IdProduct {get; set;}
        [Required]
        [MaxLength(256)]
        public string Name {get; set;}
        public string? Image {get; set;}
        [Required]
        public string Desc {get; set;}
        public int Feedback {get; set;}
        [Required]
        public decimal Price {get; set;}
        [Required]
        public int Quantity {get; set;}
        [Required]
        public DateTime DateCreate {get; set;}
        public decimal Discount {get; set;}
        [Required]
        public int IdCate {get; set;}
        public ProductCate productCates {get; set;}
        public List<CartItem> cartItems {get; set;}
        public List<ProductFeed> productFeeds {get; set;}
        public List<OrderProduct> orderProducts {get; set;}


    }
}