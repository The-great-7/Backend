namespace LSS.Services.Implementations
{
    using Contracts;
    using Data;
    using Data.Models;
    using DataModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlClient;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly LSSDbContext context;

        public UserService(LSSDbContext context)
        {
            this.context = context;
        }

        public string ChangePassword(params string[] passwordDetails)
        {
            if (!IsLogged())
            {
                return "You need to login first!";
            }

            if (passwordDetails.Length != 3)
            {
                return "Invalid arguments!";
            }

            var password = passwordDetails[0];
            var repeatedPassword = passwordDetails[1];
            var newPassword = passwordDetails[2];

            if (password != repeatedPassword)
            {
                return "Passwords do not match!";
            }

            var user = LoggedUser.User;
            user.Password = newPassword;

            if (!IsValid(user))
            {
                return "Password length is between 3 and 30!";
            }

            UpdateUser("Password", LoggedUser.User.Id, newPassword);

            return $"Password successfully changed!";
        }

        public string ChangeUsername(string newUsername)
        {
            if (!IsLogged())
            {
                return "You need to login first!";
            }

            UpdateUser("Username", LoggedUser.User.Id, newUsername);

            return "Username successfully changed!";
        }

        public string DeleteAccount()
        {
            if (!IsLogged())
            {
                return "You need to login first!";
            }

            var id = LoggedUser.User.Id;
            LogOut();

            UpdateUser("IsDeleted",id,"1");

            return "Account deleted!";
        }

        public string Login(params string[] userDetails)
        {
            var username = userDetails[0];
            var password = userDetails[1];

            var user = context.Users.FirstOrDefault(p => p.Username == username);

            if (user == null || user.Password != password)
            {
                return "Invalid username or password!";
            }

            LoggedUser.User = user;

            return $"Welcome {user.Username}!";
        }

        public string LogOut()
        {
            if (LoggedUser.User == null)
            {
                return "You need to login first!";
            }

            LoggedUser.User = null;

            return "Bye";
        }

        public string RegisterUser(params string[] userDetails)
        {
            var username = userDetails[0];
            var password = userDetails[1];
            var repeatPassword = userDetails[2];

            if (password != repeatPassword)
            {
                return "Passwords do not match!";
            }

            var user = new User()
            {
                Username = username,
                Password = password
            };

            if (!IsValid(user))
            {
                return "Invalid username or password!";
            }

            this.context.Users.Add(user);

            return $"User {user.Username} created successfully!";
        }

        private static void UpdateUser(string columnToAlter, int id, string newValue)
        {
            //Direct query to database without breaking permissions
            using (var connection = new SqlConnection("Server=.;Database=Support System;Integrated Security=True"))
            {
                connection.Open();

                var query = "UPDATE Users SET @Column = @newValue WHERE Id = @Id";
                var command = new SqlCommand(query);

                command.Parameters.AddWithValue("@Column", columnToAlter);
                command.Parameters.AddWithValue("@newValue", newValue);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        private static bool IsLogged()
        {
            if (LoggedUser.User != null || LoggedUser.User.IsDeleted == true)
            {
                return false;
            }

            return true;
        }

        private static bool IsValid(object obj)
        {
            //Checking if Annotations in current object are valid
            var context = new ValidationContext(obj);
            var validateResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, context, validateResults, true);

            return isValid;
        }
    }
}