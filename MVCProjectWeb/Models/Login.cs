using System.ComponentModel.DataAnnotations;

namespace MVCProjectWeb.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }


        [Required]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
