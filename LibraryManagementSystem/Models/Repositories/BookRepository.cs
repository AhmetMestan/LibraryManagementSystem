using LibraryManagementSystem.Models.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LibraryManagementSystem.Models.Repositories
{
    public class BookRepository(AppDbContext context) : IBookRepository
    {
        public async Task<Book> AddAsync(Book book)
        {
            var entry = await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> DeleteAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }
    }

    
    

}
