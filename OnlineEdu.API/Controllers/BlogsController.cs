using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController(IGenericService<Blog> _service, IMapper _mapper, IBlogService _blogService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var values = _blogService.TGetBlogsWithCategories();
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
    public IActionResult Create(CreateBlogDto blogDto)
    {
        var newValue = _mapper.Map<Blog>(blogDto);
        _service.TCreate(newValue);
        return Ok("Created successfully.");
    }

    
    [HttpPut]
    public IActionResult Update(UpdateBlogDto blogDto)
    {
        var value = _mapper.Map<Blog>(blogDto);
        _service.TUpdate(value);
        return Ok("Updated successfully.");
    }
}