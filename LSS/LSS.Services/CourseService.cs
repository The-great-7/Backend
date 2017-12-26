namespace LSS.Services
{
    using System;
    using System.Linq;
    using LSS.Data;
    using LSS.Data.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;
    using LSS.DataModels;
    using AutoMapper;
    using System.Collections.Generic;

    public class CourseService : ICourseService
    {
        private readonly LSSDbContext context;

        public CourseService(){}

        public CourseService(LSSDbContext context)
        {
            this.context = context;
        }

        public Course CourseById(int id)
        {
            var course = context.Courses.Find(id);

            if (course == null)
            {
                throw new ArgumentException("A course with the given Id does not exist");
            }

            context.Entry(course).State = EntityState.Detached;

            return course;
        }

        public ICollection<Course> GetCourses()
        {
            var courses = context.Courses.AsNoTracking().ToArray();

            return courses;
        }

        public ICollection<Course> AddCourse(string name)
        {
            var alreadyExists = ByName(name);
            if (alreadyExists != null)
            {
                throw new InvalidOperationException("A course with the given name already exists.");
            }

            var course = new Course()
            {
                Name = name
            };

            context.Courses.Add(course);
            context.SaveChanges();

            return context.Courses.AsNoTracking().ToList();
        }

        public ICollection<Course> ReplaceCourses(CourseDto[] coursesDtos)
        {
            DeleteCourses();

            var courses = Mapper.Map<Course[]>(coursesDtos);

            context.AddRange(courses);

            context.SaveChanges();

            return context.Courses.AsNoTracking().ToArray();
        }

        public ICollection<Course> ReplaceCourse(int id, CourseDto courseDto)
        {
            var course = context.Courses.Find(id);

            if (course == null)
            {
                throw new ArgumentException("A course with the given Id does not exist.");
            }

            course.Name = courseDto.Name;
            
            context.SaveChanges();

            return context.Courses.AsNoTracking().ToList();
        }

        public ICollection<Course> DeleteCourse(int id)
        {
            var courseToDelete = context.Courses.Find(id);

            if (courseToDelete == null)
            {
                throw new ArgumentException("A course with the given Id does not exist");
            }

            context.Courses.Remove(courseToDelete);

            context.SaveChanges();

            return context.Courses.ToList();
        }

        public void DeleteCourses()
        {
            context.Courses.Delete();

            context.SaveChanges();
        }

        private Course ByName(string name)
        {
            var course = context.Courses.SingleOrDefault(c => c.Name == name);
            //context.Entry(course).State = EntityState.Detached;

            return course;
        }
    }
}