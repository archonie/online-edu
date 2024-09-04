using AutoMapper;
using OnlineEdu.DTO.DTOs.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
    }
}