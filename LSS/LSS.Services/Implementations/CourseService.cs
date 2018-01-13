namespace LSS.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using Core;
    using Data;
    using Data.Models;
    using DataModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Z.EntityFramework.Plus;

    public class CourseService : ICourseService
    {
        private readonly LSSDbContext db;

        public CourseService(){}

        public CourseService(LSSDbContext db)
        {
            this.db = db;
        }

        public Course ById(int id)
        {
            var course = db.Courses.Find(id);

            if (course == null)
            {
                throw new ArgumentException(Constants.CourseNonExists);
            }

            this.db.Entry(course).State = EntityState.Detached;

            return course;
        }

        public IEnumerable<Course> All()
        {
            var courses = db.Courses.AsNoTracking().ToArray();

            return courses;
        }

        public IEnumerable<Course> Add(string name)
        {
            var alreadyExists = ByName(name);

            if (alreadyExists != null)
            {
                throw new InvalidOperationException(Constants.DublicateCourseName);
            }

            var course = new Course()
            {
                Name = name
            };

            this.db.Courses.Add(course);
            this.db.SaveChanges();

            return db.Courses.AsNoTracking().ToList();
        }

        public IEnumerable<Course> Replace(CourseDto[] coursesDtos)
        {
            DeleteAll();

            var courses = Mapper.Map<Course[]>(coursesDtos);

            this.db.AddRange(courses);

            this.db.SaveChanges();

            return db.Courses.AsNoTracking().ToArray();
        }

        public IEnumerable<Course> Replace(int id, CourseDto courseDto)
        {
            var course = db.Courses.Find(id);

            if (ValidateCourse(course))
            {
                course.Name = courseDto.Name;
                this.db.SaveChanges();
            }

            return db.Courses.AsNoTracking().ToList();
        }

        public IEnumerable<Course> Delete(int id)
        {
            var courseToDelete = db.Courses.Find(id);

            if (ValidateCourse(courseToDelete))
            {
                this.db.Courses.Remove(courseToDelete);
                this.db.SaveChanges();
            }

            return db.Courses.ToList();
        }

        public void DeleteAll()
        {
            this.db.Courses.Delete();

            this.db.SaveChanges();
        }

        private bool ValidateCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentException(Constants.CourseNonExists);
            }

            return true;
        }

        private Course ByName(string name)
        {
            var course = db.Courses.SingleOrDefault(c => c.Name == name);
            //context.Entry(course).State = EntityState.Detached;

            return course;
        }
    }
}