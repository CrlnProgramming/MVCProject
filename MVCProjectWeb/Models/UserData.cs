using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectWeb.Models
{
    public class UserData
    {
        [Key]
        public Guid UserId { get; set; }
        [Required,DisplayName("UserName")]
        [Range(1, 100, ErrorMessage = "User name must be between 1 and 100")]
        public string? UserName { get; set; }
        
        [Required,EmailAddress,DisplayName("UserEmail")]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }
        [Required,Phone]
        public string? PhoneNumber { get; set; }
        public DateTime UserCreatedDate { get; set; } = DateTime.Now;

    }
}
