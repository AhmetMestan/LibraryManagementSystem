using LibraryManagementSystem.Models.Repositories;
using LibraryManagementSystem.Models.Repositories.Entities;
using LibraryManagementSystem.Models.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models.Services
{
    public class BookService(IBookRepository bookRepository):IBookService
    {
        public async Task<List<BookDto>> GetAllList()
        {
            var books = await bookRepository.GetAllAsync();

            var booksAsList = books.ToList(); //foreach Inumarable da dönemediği için List'e çavirdim.

            var booksAsDto = new List<BookDto>();

            booksAsList.ForEach(p =>
            {
                booksAsDto.Add(new BookDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    Language = p.Language

                });
            });

            return booksAsDto;
        }

        public async Task<BookDto> Get(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Language = book.Language
            };
        }

        public async Task<BookDto> UpdateAsync(BookDto bookDto, int bookId)
        {
            var books =  await bookRepository.GetByIdAsync(bookId);

            if (books is null)
            {
                throw new Exception("Book not found");
            }

           books.Title = bookDto.Title;
           books.Author = bookDto.Author;
           books.Language = bookDto.Language;

           await bookRepository.UpdateAsync(books);

           return new BookDto
           {
               Id = books.Id,
               Title = books.Title,
               Author = books.Author,
               Language = books.Language
           };


        }
    }
}
