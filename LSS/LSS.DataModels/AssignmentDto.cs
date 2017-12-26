namespace LSS.DataModels
{
    using System;

    public class AssignmentDto
    {
        public string Name { get; set; }

        public int CourseId { get; set; }

        public DateTime DueDate { get; set; }
    }
}