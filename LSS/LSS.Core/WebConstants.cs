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

        public const string DublicateAssignmentName = "An Assignment with the same name already exists.";
        public const string AssignmentNonExists = "An assignment with the given Id does not exist.";

        public const string DublicateCourseName = "A course with the given name already exists.";
        public const string CourseNonExists = "A course with the given Id does not exist.";        

        public const string DublicateStudentName = "A student with the same name already exists.";
        public const string StudentNonExists = "A student with the provided Id does not exist.";
    }
}