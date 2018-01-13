namespace LSS.Data.Models
{
    using Core;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(WebConstants.CourseNameLength)]
        public string Name { get; set; }

        public IEnumerable<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();

        public IEnumerable<Assignment> Assignments { get; set; } = new HashSet<Assignment>();
    }
}