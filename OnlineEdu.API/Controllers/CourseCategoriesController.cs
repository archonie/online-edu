using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CourseCategoriesController(ICourseCategoryService _service, IMapper _mapper) : ControllerBase
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
    public IActionResult Create(CreateCourseCategoryDto courseDto)
    {
        var newValue = _mapper.Map<CourseCategory>(courseDto);
        _service.TCreate(newValue);
        return Ok("Created successfully.");
    }

    
    [HttpPut]
    public IActionResult Update(UpdateCourseCategoryDto courseDto)
    {
        var value = _mapper.Map<CourseCategory>(courseDto);
        _service.TUpdate(value);
        return Ok("Updated successfully.");
    }

    [HttpGet("ShowOnMainPage/{id}")]
    public IActionResult ShowOnMainPage(int id)
    {
        _service.TShowOnMainPage(id);
        return Ok("Changed successfully.");
    }

    [HttpGet("GetActiveCategories")]
    public IActionResult GetActiveCategories()
    {
        var values = _service.TGetFilteredList(x => x.IsShown == true);
        return Ok(values);
    }
}