﻿namespace LSS.Data.Models
{
    using Core;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.StudentNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(Constants.StudentNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(Constants.StudentNameLength)]
        public string LastName { get; set; }

        [MaxLength(Constants.StudentAddressLength)]
        public string Address { get; set; }

        [MaxLength(Constants.StudentPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public decimal? Grade { get; set; }

        public ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();

        public ICollection<StudentAssignment> Assignments { get; set; } = new HashSet<StudentAssignment>();
    }
}