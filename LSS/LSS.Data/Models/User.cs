namespace LSS.Data.Models
{
    using LSS.Core;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [MinLength(Constants.UsernameMinLength)]
        [MaxLength(Constants.UsernameMaxLength)]
        public string Username { get; set; }

        [MinLength(Constants.PasswordMinLength)]
        [MaxLength(Constants.PasswordMaxLength)]
        public string Password { get; set; }

        public bool IsDeleted { get; set; }
    }
}