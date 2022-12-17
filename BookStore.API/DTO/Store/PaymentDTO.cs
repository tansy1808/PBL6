using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Store
{
    public class PaymentDTO
    {
        public int IdOrder {get; set;}
        public int TypePay {get; set;}
    }
}