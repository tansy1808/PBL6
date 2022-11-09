using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.DTOs.Product
{
    public class CategoryDTOs
    {
        [Required]
        public int Id {get; set;}
        [Required]
        [MaxLength(256)]
        public string type {get; set;}
    }
}