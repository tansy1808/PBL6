using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.DTO.Store
{
    public class OrdersViewDTO
    {
        public int IdOrder {get; set;}
        public int IdUser {get; set;}
        public string Address {get; set;}
        public string SDT {get; set;}
        public string Status { get; set; }
        public decimal Total {get; set;}
        public List<OrderProductAPI> products {get; set;}
    }
}