using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models.Repositories.Entities
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}
