namespace LSS.Services
{
    using AutoMapper;
    using Contracts;
    using Data.Models;
    using DataModels;
    using System.Collections.Generic;

    public class MockedCourseService : ICourseService
    {
        public MockedCourseService()
        {
            this.Courses = new List<Course>();
            this.SeedCourseData();
        }

        public List<Course> Courses { get; set; }

        public ICollection<Course> GetCourses()
        {
            return this.Courses.ToArray();
        }

        public Course CourseById(int id)
        {
            return this.Courses.Find(x => x.Id == id);
        }
        
        public ICollection<Course> AddCourse(string name)
        {
            var id = this.Courses.Count;
            var course = new Course { Id = ++id, Name = name };

            this.Courses.Add(course);
            return this.Courses;
        }

        public ICollection<Course> ReplaceCourse(int id, CourseDto courseDto)
        {
            var course = this.Courses.Find(x => x.Id == id);
            course.Name = courseDto.Name;

            return this.Courses;
        }

        public ICollection<Course> ReplaceCourses(CourseDto[] coursesDtos)
        {
            DeleteCourses();

            var courses = Mapper.Map<List<Course>>(coursesDtos);

            this.Courses = courses;

            return courses.ToArray();
        }

        public ICollection<Course> DeleteCourse(int id)
        {
            this.Courses.RemoveAt(--id);
            return this.Courses;
        }

        public void DeleteCourses()
        {
            this.Courses.Clear();
        }

        #region mocked course data

        private void SeedCourseData()
        {
            this.Courses.Add(new Course { Id = 1, Name = "HTML" });
            this.Courses.Add(new Course { Id = 2, Name = "Python" });
            this.Courses.Add(new Course { Id = 3, Name = "Geography" });
            this.Courses.Add(new Course { Id = 4, Name = "History" });
        }

        #endregion
    }
}