using System.ComponentModel.DataAnnotations;

namespace BTS.Entities
{
    public class User
    {
        [Key]
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
    }
}
