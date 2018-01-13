namespace LSS.Services.Implementations
{
    using Contracts;
    using Core;
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
                return Constants.LoginFirst;
            }

            if (passwordDetails.Length != Constants.PasswordDetailsLength)
            {
                return Constants.InvalidArguments;
            }

            var password = passwordDetails[0];
            var repeatedPassword = passwordDetails[1];
            var newPassword = passwordDetails[2];

            if (password != repeatedPassword)
            {
                return Constants.PasswordsNotMatch;
            }

            var user = LoggedUser.User;
            user.Password = newPassword;

            if (!IsValid(user))
            {
                return Constants.PasswordLengthRequire;
            }

            UpdateUser("Password", LoggedUser.User.Id, newPassword);

            return Constants.PasswordChanged;
        }

        public string ChangeUsername(string newUsername)
        {
            if (!IsLogged())
            {
                return Constants.LoginFirst;
            }

            UpdateUser("Username", LoggedUser.User.Id, newUsername);

            return Constants.UsernameChanged;
        }

        public string DeleteAccount()
        {
            if (!IsLogged())
            {
                return Constants.LoginFirst;
            }

            var id = LoggedUser.User.Id;
            LogOut();

            UpdateUser("IsDeleted", id, "1");

            return Constants.AccountDeleted;
        }

        public string Login(params string[] userDetails)
        {
            var username = userDetails[0];
            var password = userDetails[1];

            var user = context.Users.FirstOrDefault(p => p.Username == username);

            if (user == null || user.Password != password)
            {
                return Constants.InvalidUsernameOrPassword;
            }

            LoggedUser.User = user;

            return $"Welcome {user.Username}!";
        }

        public string LogOut()
        {
            if (LoggedUser.User == null)
            {
                return Constants.LoginFirst;
            }

            LoggedUser.User = null;
        
            return Constants.GoodbyeMessage;
        }

        public string RegisterUser(params string[] userDetails)
        {
            var username = userDetails[0];
            var password = userDetails[1];
            var repeatPassword = userDetails[2];

            if (password != repeatPassword)
            {
                return Constants.PasswordsNotMatch;
            }

            var user = new User()
            {
                Username = username,
                Password = password
            };

            if (!IsValid(user))
            {
                return Constants.InvalidUsernameOrPassword;
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