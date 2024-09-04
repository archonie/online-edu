using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class CourseCategoryMapping : Profile
{
    public CourseCategoryMapping()
    {
        CreateMap<CourseCategory, CreateCourseCategoryDto>().ReverseMap();
        CreateMap<CourseCategory, ResultCourseCategoryDto>().ReverseMap();
        CreateMap<CourseCategory, UpdateCourseCategoryDto>().ReverseMap();
    }
}