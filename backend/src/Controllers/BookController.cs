using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebApiSample.Models;
using WebApiSample.Services;

namespace WebApiSample.Controllers
{

    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class BooksController: Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return new ObjectResult(await _bookService.GetBooks());
        }

        // GET api/Books/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
                return new NotFoundResult();

            return new ObjectResult(book);
        }

        // POST api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            await _bookService.Create(book);
            return new OkObjectResult(book);
        }

        // PUT api/Books/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(string id, [FromBody] Book book)
        {
            var bookFromDb = await _bookService.GetBook(id);

            if (bookFromDb == null)
                return new NotFoundResult();

            book.Id = bookFromDb.Id;
            await _bookService.Update(book);

            return new OkObjectResult(book);
        }

        // DELETE api/Books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var post = await _bookService.GetBook(id);

            if (post == null)
                return new NotFoundResult();

            await _bookService.Delete(id);

            return new OkResult();
        }
    }
}
