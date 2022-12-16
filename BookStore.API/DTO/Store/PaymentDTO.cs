using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Store
{
    public class PaymentDTO
    {
        [Required]
        public int IdOrder {get; set;}
        [Required]
        public int Amount {get; set;}
        public DateTime Date {get; set;}
        [Required]
        public int TypePay {get; set;}
    }
}