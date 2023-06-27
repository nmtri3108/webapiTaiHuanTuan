using Microsoft.EntityFrameworkCore;
using WebApiTaiHuanTuan.Models;

namespace WebApiTaiHuanTuan.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    { }

    public DbSet<Category> Categories { get; set; }
}