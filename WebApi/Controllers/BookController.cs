
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private BookService _BookService;

        public BookController(BookService bookService)
        {
            _BookService = bookService;
        }


        [HttpGet("GetInfo")]
        public async Task<List<GetBooks>> GetAuthors()
        {
            return await _BookService.GetBooks();
        }

        [HttpPost("Insert")]
        public async Task<int> InsertBooks(Book book)
        {
            return await _BookService.InsertBooks(book);
        }

        [HttpPut("Update")]
        public async Task<int> UpdateBooks(Book book)
        {
            return await _BookService.UpdateBooks(book);
        }

        [HttpDelete("Delete")]
        public async Task<int> DeleteBook(int id)
        {
            return await _BookService.DeleteBook(id);
        }
    }
}