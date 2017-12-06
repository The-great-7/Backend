namespace LSS.Services.Contracts
{
    using LSS.Data.Models;
    using LSS.DataModels;

    public interface ICourseService
    {
        Course CourseById(int id);

        Course[] GetCourses();

        Course AddCourse(string name);

        Course[] ReplaceCourses(CourseDto[] coursesDtos);

        Course ReplaceCourse(int id, CourseDto courseDto);

        void DeleteCourse(int id);

        void DeleteCourses();
    }
}