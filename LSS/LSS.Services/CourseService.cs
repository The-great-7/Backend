namespace LSS.Services
{
    using System.Linq;
    using LSS.Data;
    using LSS.Data.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;
    using LSS.DataModels;
    using AutoMapper;

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

            context.Entry(course).State = EntityState.Detached;

            return course;
        }

        public Course[] GetCourses()
        {
            var courses = context.Courses.AsNoTracking().ToArray();

            return courses;
        }

        public Course AddCourse(string name)
        {
            var courses = context.Courses;

            var course = new Course()
            {
                Name = name
            };

            courses.Add(course);
            context.SaveChanges();

            //do we want ids?
            //return ByName(name);
            return course;
        }

        public Course[] ReplaceCourses(CourseDto[] coursesDtos)
        {
            DeleteCourses();

            var courses = Mapper.Map<Course[]>(coursesDtos);

            context.AddRange(courses);

            context.SaveChanges();

            return context.Courses.AsNoTracking().ToArray();
        }

        public Course ReplaceCourse(int id, CourseDto courseDto)
        {
            var course = context.Courses.Find(id);

            course.Name = courseDto.Name;
            
            context.SaveChanges();
            
            //do we want ids?
            //return ByName(course.Name);
            return course;
        }

        public void DeleteCourse(int id)
        {
            var courseToDelete = context.Courses.Find(id);

            context.Courses.Remove(courseToDelete);

            context.SaveChanges();
        }

        public void DeleteCourses()
        {
            context.Courses.Delete();

            context.SaveChanges();
        }

        private Course ByName(string name)
        {
            var course = context.Courses.SingleOrDefault(c => c.Name == name);
            context.Entry(course).State = EntityState.Detached;

            return course;
        }
    }
}