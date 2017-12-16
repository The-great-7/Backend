﻿namespace LSS.Services
{
    using LSS.Data.Models;
    using LSS.DataModels;
    using LSS.Services.Contracts;
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
            int id = this.Courses.Count;
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
            List<Course> replacedCourses = new List<Course>();

            foreach (var course in coursesDtos)
            {
                var currentCourse = this.Courses.Find(x => x.Id == course.Id);
                currentCourse.Name = course.Name;
                replacedCourses.Add(currentCourse);
            }
            return replacedCourses.ToArray();
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
