namespace LSS.Services.Contracts
{
    using Data.Models;
    using DataModels;
    using System.Collections.Generic;

    public interface ICourseService
    {
        Course ById(int id);

        IEnumerable<Course> All();

        IEnumerable<Course> Add(string name);

        IEnumerable<Course> Replace(CourseDto[] coursesDtos);

        IEnumerable<Course> Replace(int id, CourseDto courseDto);

        IEnumerable<Course> Delete(int id);

        void DeleteAll();
    }
}