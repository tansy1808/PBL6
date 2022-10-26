using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Enities
{
    public class User
    {
        [Key]
        public int IdUser {get; set;}
        [Required]
        [MaxLength(256)]
        public string Username {get; set;}
        [MaxLength(256)]
        public byte[] PasswordHash {get; set;}
        [MaxLength(256)]
        public byte[] PasswordSalt {get; set;}
        [MaxLength(256)]
        public string Name {get; set;}
        [MaxLength(256)]
        public string Address {get; set;}
        [MaxLength(15)]
        public string Contact {get; set;}
        public int RoleId {get; set;}
        public Role Role {get; set;}
        public List<UserPay> UserPays {get; set;}
    }
}