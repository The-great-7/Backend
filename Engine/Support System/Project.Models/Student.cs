namespace Project.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
            StudentAssignments = new HashSet<StudentAssignment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Grade { get; set; }

        public int StudentCourseId { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public int StudentAssignmentId { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
