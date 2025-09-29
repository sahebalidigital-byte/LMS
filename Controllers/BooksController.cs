using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddNewBook([FromBody] Book book)
        {
            var id = await _bookRepository.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id, controller = "books" }, $"Book Added Successfully.\nYour Book Id Is : {id}");
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book, [FromRoute] int id)
        {
            await _bookRepository.UpdateBook(id, book);
            return Ok("Book Has Been Updated Successfully....");
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBook(id);
            return Ok("Book Deleted Successfully....");
        }
    }
}
