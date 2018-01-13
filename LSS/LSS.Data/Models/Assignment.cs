namespace LSS.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Assignment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course {get; set; }

        public DateTime DueDate { get; set; }

        public ICollection<StudentAssignment> Students { get; set; } = new HashSet<StudentAssignment>();
    }
}