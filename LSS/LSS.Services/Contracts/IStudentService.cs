namespace LSS.Services.Contracts
{
    using LSS.Data.Models;
    using LSS.Api.Dtos;

    public interface IStudentService
    {
        Student StudentById(int id);

        Student[] GetStudents();

        Student AddStudent(StudentDto studentDto);

        Student[] ReplaceStudents(Student[] students);

        Student ReplaceStudent(int id, StudentDto studentDto);

        void DeleteStudent(int id);

        void DeleteStudents();
    }
}