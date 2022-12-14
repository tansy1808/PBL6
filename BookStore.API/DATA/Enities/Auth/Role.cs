using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities.Auth
{
    public class Role
    {
        [Key]
        public int IdRole {get; set;}
        [Required]
        [MaxLength(256)]
        public string RoleName {get; set;}
        public List<User> users {get; set;}
    }
}