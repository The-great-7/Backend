namespace LSS.Core
{
    public class Constants
    {
        public const int AssigmentNameLength = 70;
        public const int DefaultDueDateDays = 7;

        public const int CourseNameLength = 70;

        public const int StudentNameLength = 30;
        public const int StudentAddressLength = 200;
        public const int StudentPhoneNumberLength = 10;

        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 30;
        public const int PasswordMinLength = 3;
        public const int PasswordMaxLength = 30;

        public const int PasswordDetailsLength = 3;
     
        public const string LoginFirst = "You need to login first!";
        public const string InvalidArguments = "Invalid arguments!";
        public const string InvalidUsernameOrPassword = "Invalid username or password!";

        public const string PasswordsNotMatch = "Passwords doesn't match!";
        public const string PasswordLengthRequire = "Password length must be between 3 and 30 symbols!";
        public const string PasswordChanged = "Password successfully changed!";

        public const string UsernameChanged = "Username successfully changed!";
        public const string AccountDeleted = "Account deleted!";
        public const string GoodbyeMessage = "Bye!";

        public const string DublicateAssignmentName = "Anassignment with the same name already exists.";
        public const string AssignmentNonExists = "An assignment with the given Id does not exist.";

        public const string DublicateCourseName = "A course with the given name already exists.";
        public const string CourseNonExists = "A course with the given Id does not exist.";

        public const string DublicateStudentName = "A student with the same name already exists.";
        public const string StudentNonExists = "A student with the provided Id does not exist.";
    }
}