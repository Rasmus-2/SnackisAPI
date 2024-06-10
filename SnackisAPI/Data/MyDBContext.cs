using Microsoft.EntityFrameworkCore;

namespace SnackisAPI.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) 
        {            
        }

        public DbSet<Models.Category> Category {  get; set; }
    }
}
