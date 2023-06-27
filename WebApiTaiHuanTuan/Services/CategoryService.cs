using WebApiTaiHuanTuan.Data;
using WebApiTaiHuanTuan.Models;
using WebApiTaiHuanTuan.Services.IServices;

namespace WebApiTaiHuanTuan.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _db;

    public CategoryService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IEnumerable<Category> GetAll()
    {
        return _db.Categories.ToList();
    }

    public Category GetById(int id)
    {
        return _db.Categories.Find(id);
    }

    public bool Delete(int id)
    {
        var category = GetById(id);
        if (category == null)
        {
            return false;
        }

        _db.Categories.Remove(category);
        _db.SaveChanges();
        
        return true;
    }

    public void Create(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
    }

    public void Update(int id, Category category)
    {
        var categoryDb = GetById(id);
        
        categoryDb.Description = category.Description;
        categoryDb.Name = category.Name;
       
        _db.Categories.Update(categoryDb);
        _db.SaveChanges();
    }
}