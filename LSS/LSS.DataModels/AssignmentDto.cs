namespace LSS.Api.Dtos
{
    using System;

    public class AssignmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CourseId { get; set; }

        public DateTime DueDate { get; set; }
    }
}