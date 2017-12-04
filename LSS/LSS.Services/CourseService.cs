namespace LSS.Services
{
    using System.Linq;
    using LSS.Data;
    using LSS.Data.Models;
    using LSS.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
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

            return ByName(name);
        }

        public Course[] ReplaceCourses(Course[] courses)
        {
            DeleteCourses();

            context.AddRange(courses);

            context.SaveChanges();

            return context.Courses.AsNoTracking().ToArray();
        }

        public Course ReplaceCourse(int id, Course course)
        {
            DeleteCourse(id);

            context.Courses.Add(course);
            context.SaveChanges();

            return context.Courses.Find(course);
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