namespace LSS.Services
{
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

            context.Add(student);

            context.SaveChanges();

            //do we want ids?
            //var studentWithId = ByName(student.FirstName, student.MiddleName, student.LastName);

            return student;
        }

        public Student[] ReplaceStudents(StudentDto[] studentsDtos)
        {
            context.Students.Delete();

            var students = Mapper.Map<Student[]>(studentsDtos);

            context.Students.AddRange(students);

            context.SaveChanges();

            //do we want ids?
            return students;
        }

        public Student ReplaceStudent(int id, StudentDto studentDto)
        {
            var student = context.Students.Find(id);

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
    }
}