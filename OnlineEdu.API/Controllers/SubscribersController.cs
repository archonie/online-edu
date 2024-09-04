using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SubscribersDto(IGenericService<Subscriber> _service, IMapper _mapper) : ControllerBase
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
    public IActionResult Create(CreateSubscriberDto subscriberDto)
    {
        var newValue = _mapper.Map<Subscriber>(subscriberDto);
        _service.TCreate(newValue);
        return Ok("Created successfully.");
    }

    
    [HttpPut]
    public IActionResult Update(UpdateSubscriberDto subscriberDto)
    {
        var value = _mapper.Map<Subscriber>(subscriberDto);
        _service.TUpdate(value);
        return Ok("Updated successfully.");
    }
}