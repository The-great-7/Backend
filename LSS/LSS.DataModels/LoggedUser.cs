namespace LSS.DataModels
{
    using LSS.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class LoggedUser
    {
        public static User User { get; set; }
    }
}
