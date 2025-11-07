using BookStore.Application.Services;
using BookStore.Contracts;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
 
        public BooksController(IBooksService booksService) 
        {
            this._booksService = booksService;
        }  
        
        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetAllBoks();
            var responce = books.Select(b => new BooksResponse(b.Id, b.Titel, b.Description, b.Price));
            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequst requst)
        {
            var (book, error) = Book.Create(Guid.NewGuid(), requst.Title, requst.Description, requst.Price);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var bookId=await _booksService.CreateBook(book); 
            return Ok(bookId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequst requst)
        {
            
            var bookId = await _booksService.UpdateBook(id, requst.Title, requst.Description, requst.Price);
            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {

            var bookId = await _booksService.DeleteBook(id);
            return Ok(bookId);
        }
    }
}
