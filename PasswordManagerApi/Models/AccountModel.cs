using System.ComponentModel.DataAnnotations;

namespace PasswordManagerApi.Models
{
    public class AccountModel
    {
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; }
        [Url]
        public string? Url { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Notes { get; set; }
        public bool? Favorite { get; set; } 
    }
}