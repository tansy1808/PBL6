using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Data.Enities.Product
{
    public class ProductCate
    {
        public int Id {get; set;}
        public string categoryType {get; set;}
        public List<Products> products {get; set;}
        
    }
}