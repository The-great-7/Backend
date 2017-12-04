namespace LSS.Api
{
    using AutoMapper;
    using LSS.Api.Dtos;
    using LSS.Data.Models;

    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<AssignmentDto, Assignment>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }
    }
}