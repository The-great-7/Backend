namespace LSS.Api
{
    using AutoMapper;
    using Data.Models;
    using DataModels;

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