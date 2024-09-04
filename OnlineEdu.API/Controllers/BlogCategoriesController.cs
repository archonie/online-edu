using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BlogCategoriesController(IGenericService<BlogCategory> _service, IMapper _mapper) : ControllerBase
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
    public IActionResult Create(CreateBlogCategoryDto blogDto)
    {
        var newValue = _mapper.Map<BlogCategory>(blogDto);
        _service.TCreate(newValue);
        return Ok("Created successfully.");
    }

    
    [HttpPut]
    public IActionResult Update(UpdateBlogCategoryDto blogDto)
    {
        var value = _mapper.Map<BlogCategory>(blogDto);
        _service.TUpdate(value);
        return Ok("Updated successfully.");
    }
}