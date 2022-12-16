using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities.Order
{
    public class MethodPay
    {
        [Key]
        public int Id {get; set;}
        [MaxLength(256)]
        public string TypeName {get; set;}
        public List<Payment> payments {get; set;}
    }
}