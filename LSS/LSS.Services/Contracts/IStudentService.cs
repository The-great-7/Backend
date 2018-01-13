namespace LSS.Services.Contracts
{
    using DataModels;
    using Models;
    using System.Collections.Generic;

    public interface IStudentService
    {
        StudentServiceModel ById(int id);

        IEnumerable<StudentServiceModel> All();

        StudentServiceModel Add(StudentDto studentDto);

        IEnumerable<StudentServiceModel> Replace(IEnumerable<StudentDto> studentsDtos);

        StudentServiceModel Replace(int id, StudentDto studentDto);

        IEnumerable<StudentServiceModel> Delete(int id);

        void DeleteAll();
    }
}