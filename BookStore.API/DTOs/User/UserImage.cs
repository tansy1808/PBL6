using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.DTOs.User
{
    public class UserImage
    {
        [Required]
        [MaxLength(256)]
        public string Userimage {get; set;}
    }
}