using AutoMapper;
using OnlineEdu.DTO.DTOs.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class TestimonialMapping : Profile
{
    public TestimonialMapping()
    {
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
    }
}