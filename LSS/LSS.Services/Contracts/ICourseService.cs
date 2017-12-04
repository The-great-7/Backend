namespace LSS.Services.Contracts
{
    using LSS.Data.Models;

    public interface ICourseService
    {
        Course CourseById(int id);

        Course[] GetCourses();

        Course AddCourse(string name);

        Course[] ReplaceCourses(Course[] courses);

        Course ReplaceCourse(int id, Course course);

        void DeleteCourse(int id);

        void DeleteCourses();
    }
}