namespace LSS.Services.Contracts
{
    using Data.Models;
    using DataModels;
    using System.Collections.Generic;

    public interface ICourseService
    {
        Course CourseById(int id);

        ICollection<Course> GetCourses();

        ICollection<Course> AddCourse(string name);

        ICollection<Course> ReplaceCourses(CourseDto[] coursesDtos);

        ICollection<Course> ReplaceCourse(int id, CourseDto courseDto);

        ICollection<Course> DeleteCourse(int id);

        void DeleteCourses();
    }
}