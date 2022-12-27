using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data.Enities.Product;

namespace BookStore.API.DTO.Product
{
    public class ViewCategory
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ProductCate data { get; set; }
    }
}