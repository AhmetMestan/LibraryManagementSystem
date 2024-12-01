using LibraryManagementSystem.Models.Services.DTOs;

namespace LibraryManagementSystem.Models.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllList();
        Task<BookDto> Get(int id);
    }
}
