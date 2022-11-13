using System.ComponentModel.DataAnnotations;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.Data.Enities.Order;

namespace BookStore.API.Data.Enities.Product
{
    public class Products
    {
        [Key]
        public int IdProduct {get; set;}
        [Required]
        [MaxLength(256)]
        public string Name {get; set;}
        [Required]
        [MaxLength(256)]
        public string Image {get; set;}
        [Required]
        [MaxLength(256)]
        public string Desc {get; set;}
        [Required]
        public int Feedback {get; set;}
        [Required]
        public decimal Frice {get; set;}
        [Required]
        public int Quantity {get; set;}
        [Required]
        public decimal Discount {get; set;}
        [Required]
        public int IdCate {get; set;}
        public ProductCate productCates {get; set;}
        public CartItem cartItems {get; set;}
        public List<ProductFeed> productFeeds {get; set;}
        public List<OrderProduct> orderProducts {get; set;}


    }
}