namespace LSS.Data.Models
{
    using LSS.Core;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(WebConstants.AssigmentNameLength)]
        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course {get; set; }

        [Required]
        [DefaultValue(typeof(DateTime), "DateTime.Now.AddDays(WebConstants.DefaultDueDateDays)")]
        public DateTime DueDate { get; set; }

        public ICollection<StudentAssignment> Students { get; set; } = new HashSet<StudentAssignment>();
    }
}