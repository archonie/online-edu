using AutoMapper;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class BannerMapping : Profile
{
    public BannerMapping()
    {
        CreateMap<Banner, CreateBannerDto>().ReverseMap();
        CreateMap<Banner, UpdateBannerDto>().ReverseMap();
    }
}