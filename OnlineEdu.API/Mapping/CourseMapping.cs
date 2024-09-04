using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class CourseMapping : Profile
{
    public CourseMapping()
    {
        CreateMap<Course, CreateCourseDto>().ReverseMap();
        CreateMap<Course, UpdateCourseDto>().ReverseMap();
        CreateMap<Course, ResultCourseDto>().ReverseMap();
    }
}