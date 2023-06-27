using Microsoft.AspNetCore.Mvc;
using WebApiTaiHuanTuan.Data;
using WebApiTaiHuanTuan.Models;

namespace WebApiTaiHuanTuan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    // GET http://localhost:5000/api/Category
    public IEnumerable<Category> GetAll()
    {
        return _db.Categories.ToList();
    }

    [HttpGet("{id:int}")]
    // GET http://localhost:5000/api/Category/{id}
    public Category GetById(int id)
    {
        return _db.Categories.Find(id);
    }
    
    [HttpDelete("{id:int}")]
    // Delete http://localhost:5000/api/Category/{id}
    public IActionResult Delete(int id)
    {
        var category = _db.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(category);
        _db.SaveChanges();
        
        return Ok();
    }
    
    [HttpPost]
    // Post http://localhost:5000/api/Category
    public IActionResult Create([FromBody] Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        
        return StatusCode(201);
    }
    
    [HttpPut("{id:int}")]
    // Put http://localhost:5000/api/Category/{id}
    public IActionResult Create([FromRoute] int id, [FromBody] Category category)
    {
        var categoryDb = _db.Categories.Find(id);
        
        categoryDb.Description = category.Description;
        categoryDb.Name = category.Name;
       
        _db.Categories.Update(categoryDb);
        _db.SaveChanges();
        
        return StatusCode(201);
    }
}