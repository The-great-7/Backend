namespace LSS.Data.Models
{
    using System.Collections.Generic;

    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
    }
}