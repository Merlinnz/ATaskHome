
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController
    {
        private AuthorService _AuthorService;

        public AuthorController(AuthorService authorService)
        {
            _AuthorService = authorService;
        }


        [HttpGet("GetInfo")]
        public async Task<List<Author>> GetAuthors()
        {
            return await _AuthorService.GetAuthors();
        }

        [HttpPost("Insert")]
        public async Task<int> InsertAuthors(Author author)
        {
            return await _AuthorService.InsertAuthors(author);
        }

        [HttpPut("Update")]
        public async Task<int> UpdateAuthors(Author author)
        {
            return await _AuthorService.UpdateAuthors(author);
        }

        [HttpDelete("Delete")]
        public async Task<int> DeleteAuthors(int id)
        {
            return await _AuthorService.DeleteAuthors(id);
        }
    }
}