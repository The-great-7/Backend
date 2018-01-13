namespace LSS.Data.Models
{
    using LSS.Core;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [MinLength(WebConstants.UsernameMinLength)]
        [MaxLength(WebConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [MinLength(WebConstants.PasswordMinLength)]
        [MaxLength(WebConstants.PasswordMaxLength)]
        public string Password { get; set; }

        public bool IsDeleted { get; set; }
    }
}