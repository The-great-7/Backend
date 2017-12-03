namespace LearningSupportSystemData.Models
{
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
            Assignments = new HashSet<Assignment>();
        }

        public Course(int id, string name)
        {
            this.CourseId = id;
            this.CourseName = name;
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}