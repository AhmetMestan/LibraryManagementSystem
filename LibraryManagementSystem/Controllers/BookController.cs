using LibraryManagementSystem.Models.Repositories;
using LibraryManagementSystem.Models.Services;
using LibraryManagementSystem.Models.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> Get()
        {
            return await bookService.GetAllList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            return await bookService.Get(id);
        }
    }
}
