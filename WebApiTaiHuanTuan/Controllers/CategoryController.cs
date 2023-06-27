using Microsoft.AspNetCore.Mvc;
using WebApiTaiHuanTuan.Models;
using WebApiTaiHuanTuan.Services.IServices;

namespace WebApiTaiHuanTuan.Controllers;

[ApiController]
[Route("api/[controller]")]
// http://localhost:5000/api/Category
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    // GET http://localhost:5000/api/Category
    public IEnumerable<Category> GetAll()
    {
        return _categoryService.GetAll();
    }

    [HttpGet("{id:int}")]
    // GET http://localhost:5000/api/Category/{id}
    public Category GetById(int id)
    {
        return _categoryService.GetById(id);
    }
    
    [HttpDelete("{id:int}")]
    // Delete http://localhost:5000/api/Category/{id}
    public IActionResult Delete(int id)
    {
        var result = _categoryService.Delete(id);
        
        if (!result)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpPost]
    // Post http://localhost:5000/api/Category
    public IActionResult Create([FromBody] Category category)
    {
        _categoryService.Create(category);
        return StatusCode(201);
    }
    
    [HttpPut("{id:int}")]
    // Put http://localhost:5000/api/Category/{id}
    public IActionResult Update([FromRoute] int id, [FromBody] Category category)
    {
        _categoryService.Update(id, category);
        return StatusCode(201);
    }
}