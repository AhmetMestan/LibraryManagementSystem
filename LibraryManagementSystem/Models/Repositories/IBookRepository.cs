using LibraryManagementSystem.Models.Repositories.Entities;

namespace LibraryManagementSystem.Models.Repositories
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<Book> DeleteAsync(Book book);
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();

    }
}
