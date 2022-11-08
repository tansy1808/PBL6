using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities.Product
{
    public class Products
    {
        [Key]
        public int IdProduct {get; set;}
        [MaxLength(256)]
        public string Name {get; set;}
        [MaxLength(256)]
        public string Image {get; set;}
        [MaxLength(256)]
        public string Desc {get; set;}
        public int feedback {get; set;}
        public decimal price {get; set;}
        public int Quantity {get; set;}
        public decimal discount {get; set;}
        public int IdCate {get; set;}
        public ProductCate ProductCate {get; set;}

    }
}