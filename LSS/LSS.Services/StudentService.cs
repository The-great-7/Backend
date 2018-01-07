namespace LSS.Services
{
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Models;
    using DataModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Z.EntityFramework.Plus;

    public class StudentService : IStudentService
    {
        private readonly LSSDbContext context;

        public StudentService(LSSDbContext context)
        {
            this.context = context;
        }

        public Student StudentById(int id)
        {
            var student = context.Students.Find(id);
            
            return student;
        }

        public Student[] GetStudents()
        {
            var students = context.Students.AsNoTracking().ToArray();

            return students;
        }

        public Student AddStudent(StudentDto studentDto)
        {
            var student = Mapper.Map<Student>(studentDto);

            CheckIfStudentAlreadyExists(student);

            this.context.Add(student);
            this.context.SaveChanges();
            this.context.Entry(student).State = EntityState.Detached;

            return student;
        }

        public Student[] ReplaceStudents(StudentDto[] studentsDtos)
        {
            DeleteStudents();

            var students = Mapper.Map<Student[]>(studentsDtos);

            this.context.Students.AddRange(students);
            this.context.SaveChanges();

            return students;
        }

        public Student ReplaceStudent(int id, StudentDto studentDto)
        {
            var student = context.Students.Find(id);

            ValidateStudent(student);

            student.FirstName = studentDto.FirstName;
            student.MiddleName = studentDto.MiddleName;
            student.LastName = studentDto.LastName;
            student.Address = studentDto.Address;
            student.Grade = studentDto.Grade;
            student.PhoneNumber = studentDto.PhoneNumber;

            this.context.SaveChanges();

            return student;
        }

        public ICollection<Student> DeleteStudent(int id)
        {
            var student = context.Students.Find(id);

            ValidateStudent(student);

            this.context.Students.Remove(student);

            this.context.SaveChanges();

            return this.context.Students.ToList();
        }

        public void DeleteStudents()
        {
            this.context.Students.Delete();
            this.context.SaveChanges();
        }

        private Student ByName(string firstName, string middleName, string lastName)
        {
            var student = context.Students.AsNoTracking()
                .FirstOrDefault(s => s.FirstName == firstName &&
                s.MiddleName == middleName &&
                s.LastName == lastName);

            return student;
        }

        private static void ValidateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException("A student with the provided Id does not exist");
            }
        }

        private void CheckIfStudentAlreadyExists(Student student)
        {
            if (context.Students.Any(s => s.FirstName == student.FirstName && s.MiddleName == student.MiddleName &&
                                          s.LastName == student.LastName))
            {
                throw new InvalidOperationException("A student with the same name already exists");
            }
        }
    }
}