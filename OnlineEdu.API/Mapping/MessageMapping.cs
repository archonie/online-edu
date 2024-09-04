using AutoMapper;
using OnlineEdu.DTO.DTOs.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
        CreateMap<Message, CreateMessageDto>().ReverseMap();
    }
}