namespace LSS.Data.Models
{
    using System.Collections.Generic;

    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

        public ICollection<Assignment> Assignments { get; set; } = new HashSet<Assignment>();
    }
}