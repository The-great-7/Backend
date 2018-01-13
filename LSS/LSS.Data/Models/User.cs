namespace LSS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Username { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Password { get; set; }

        public bool IsDeleted { get; set; }
    }
}