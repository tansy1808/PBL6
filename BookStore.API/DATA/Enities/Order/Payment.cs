using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities.Order
{
    public class Payment
    {
        [Key]
        public int IdPay {get; set;}
        [Required]
        public int IdOrder {get; set;}
        public int Amount {get; set;}
        [Required]
        public DateTime Date {get; set;}
        public int TypePay {get; set;}
        public Orders orders {get; set;}
        public MethodPay methodPays {get; set;}
    }
}