namespace LSS.Services
{
    using System;
    using System.Linq;
    using LSS.DataModels;
    using LSS.Data;
    using LSS.Data.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
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

            context.Add(student);

            context.SaveChanges();

            context.Entry(student).State = EntityState.Detached;
            return student;
        }

        public Student[] ReplaceStudents(StudentDto[] studentsDtos)
        {
            DeleteStudents();

            var students = Mapper.Map<Student[]>(studentsDtos);

            context.Students.AddRange(students);

            context.SaveChanges();

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

            context.SaveChanges();

            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = context.Students.Find(id);

            ValidateStudent(student);

            context.Students.Remove(student);

            context.SaveChanges();
        }

        public void DeleteStudents()
        {
            context.Students.Delete();

            context.SaveChanges();
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