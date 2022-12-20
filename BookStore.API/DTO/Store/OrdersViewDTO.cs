using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.DTO.Store
{
    public class OrdersViewDTO
    {
        public int IdUser {get; set;}
        public string Address {get; set;}
        public string Status { get; set; }
        public int Total {get; set;}
        public List<OrderProductAPI> products {get; set;}
    }
}