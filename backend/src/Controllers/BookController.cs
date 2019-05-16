using System.Collections.Generic;
using System.Linq;
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
            var Book = await _bookService.GetBook(id);
            if (Book == null)
                return new NotFoundResult();

            return new ObjectResult(Book);
        }

        // POST api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            await _bookService.Create(book);
            return new OkObjectResult(book);
        }

        // PUT api/Books/1
        // [HttpPut("{id}")]
        // public async Task<ActionResult<Book>> Put(long id, [FromBody] Book Book)
        // {
        //     var BookFromDb = await _bookService.GetBook(id);

        //     if (BookFromDb == null)
        //         return new NotFoundResult();

        //     Book.Id = BookFromDb.Id;
        //     Book.InternalId = BookFromDb.InternalId;
        //     await _bookService.Update(Book);

        //     return new OkObjectResult(Book);
        // }

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
