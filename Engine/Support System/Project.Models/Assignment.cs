namespace Project.Models
{
    using System.Collections.Generic;

    public class Assignment
    {
        public Assignment()
        {
            StudentAssignments = new HashSet<StudentAssignment>();
        }

        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }

        public int CourseId { get; set; }
        public Course Course {get; set; }

        public int StudentAssignmentId { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
