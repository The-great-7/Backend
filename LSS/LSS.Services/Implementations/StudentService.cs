namespace LSS.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using DataModels;
    using LSS.Core;
    using LSS.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Z.EntityFramework.Plus;

    public class StudentService : IStudentService
    {
        private readonly LSSDbContext db;

        public StudentService(LSSDbContext db)
        {
            this.db = db;
        }

        public StudentServiceModel ById(int id)
        {
            var result = this.db
                .Students
                .Where(s => s.Id == id)
                .ProjectTo<StudentServiceModel>()
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<StudentServiceModel> All()
        {
            var result = this.db
                .Students
                .ProjectTo<StudentServiceModel>()
                .ToList();

            return result;
        }

        public StudentServiceModel Add(StudentDto studentDto)
        {
            var student = Mapper.Map<Student>(studentDto);

            if (!this.StudentExists(student))
            {
                this.db.Add(student);
                this.db.SaveChanges();
                this.db.Entry(student).State = EntityState.Detached;
            }

            // TODO: this is dumb, change it as you wish
            var result = Mapper.Map<StudentServiceModel>(student);

            return result;
        }

        public IEnumerable<StudentServiceModel> Replace(IEnumerable<StudentDto> studentsDtos)
        {
            this.DeleteAll();

            var students = Mapper.Map<IEnumerable<Student>>(studentsDtos).AsQueryable();

            this.db.Students.AddRange(students);
            this.db.SaveChanges();

            // TODO: this is dumb, change it as you wish
            var result = students.ProjectTo<StudentServiceModel>().ToList();

            return result;
        }

        public StudentServiceModel Replace(int id, StudentDto studentDto)
        {
            var student = this.db.Students.Find(id);

            if (ValidateStudent(student))
            {
                student.FirstName = studentDto.FirstName;
                student.MiddleName = studentDto.MiddleName;
                student.LastName = studentDto.LastName;
                student.Address = studentDto.Address;
                student.Grade = studentDto.Grade;
                student.PhoneNumber = studentDto.PhoneNumber;
            }       

            this.db.SaveChanges();
        
            // TODO: this is dumb, change it as you wish
            var result = Mapper.Map<StudentServiceModel>(student);

            return result;
        }

        public IEnumerable<StudentServiceModel> Delete(int id)
        {
            var student = this.db.Students.Find(id);

            if (ValidateStudent(student))
            {
                this.db.Students.Remove(student);
                this.db.SaveChanges();
            }

            var result = this.db.Students.ProjectTo<StudentServiceModel>();

            return result;
        }

        public void DeleteAll()
        {
            this.db.Students.Delete();
            this.db.SaveChanges();
        }

        private bool ValidateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException(Constants.StudentNonExists);
            }

            return true;
        }

        private bool StudentExists(Student student)
        {
            if (this.db.Students.Any(s => s.FirstName == student.FirstName 
                                            && s.MiddleName == student.MiddleName 
                                            && s.LastName == student.LastName))
            {
                throw new InvalidOperationException(Constants.DublicateStudentName);
            }

            return false;
        }
    }
}