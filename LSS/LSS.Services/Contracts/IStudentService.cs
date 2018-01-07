namespace LSS.Services.Contracts
{
    using Data.Models;
    using DataModels;

    public interface IStudentService
    {
        Student StudentById(int id);

        Student[] GetStudents();

        Student AddStudent(StudentDto studentDto);

        Student[] ReplaceStudents(StudentDto[] students);

        Student ReplaceStudent(int id, StudentDto studentDto);

        void DeleteStudent(int id);

        void DeleteStudents();
    }
}