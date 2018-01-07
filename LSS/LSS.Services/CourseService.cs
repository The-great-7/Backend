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

            this.context.Entry(course).State = EntityState.Detached;

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

            this.context.Courses.Add(course);
            this.context.SaveChanges();

            return context.Courses.AsNoTracking().ToList();
        }

        public ICollection<Course> ReplaceCourses(CourseDto[] coursesDtos)
        {
            DeleteCourses();

            var courses = Mapper.Map<Course[]>(coursesDtos);

            this.context.AddRange(courses);

            this.context.SaveChanges();

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

            this.context.SaveChanges();

            return context.Courses.AsNoTracking().ToList();
        }

        public ICollection<Course> DeleteCourse(int id)
        {
            var courseToDelete = context.Courses.Find(id);

            if (courseToDelete == null)
            {
                throw new ArgumentException("A course with the given Id does not exist");
            }

            this.context.Courses.Remove(courseToDelete);

            this.context.SaveChanges();

            return context.Courses.ToList();
        }

        public void DeleteCourses()
        {
            this.context.Courses.Delete();

            this.context.SaveChanges();
        }

        private Course ByName(string name)
        {
            var course = context.Courses.SingleOrDefault(c => c.Name == name);
            //context.Entry(course).State = EntityState.Detached;

            return course;
        }
    }
}