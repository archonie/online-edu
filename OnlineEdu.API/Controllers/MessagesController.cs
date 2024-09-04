using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController(IGenericService<Message> _service, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var values = _service.TGetList();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _service.TGetById(id);
        return Ok(value);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.TDelete(id);
        return Ok("Deleted successfully.");
    }

    [HttpPost]
    public IActionResult Create(CreateMessageDto messageDto)
    {
        var newValue = _mapper.Map<Message>(messageDto);
        _service.TCreate(newValue);
        return Ok("Created successfully.");
    }


    [HttpPut]
    public IActionResult Update(UpdateMessageDto messageDto)
    {
        var value = _mapper.Map<Message>(messageDto);
        _service.TUpdate(value);
        return Ok("Updated successfully.");
    }
}