using AutoMapper;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class BlogMapping : Profile
{
    public BlogMapping()
    {
        CreateMap<Blog, CreateBlogDto>().ReverseMap();
        CreateMap<Blog, UpdateBlogDto>().ReverseMap();
        CreateMap<Blog, ResultBlogDto>().ReverseMap();
    }
}