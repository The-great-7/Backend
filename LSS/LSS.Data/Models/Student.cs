namespace LSS.Data.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Grade { get; set; }

        public ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();

        public ICollection<StudentAssignment> Assignments { get; set; } = new HashSet<StudentAssignment>();
    }
}