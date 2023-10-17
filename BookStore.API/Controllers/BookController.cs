using BookStore.API.Data;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BookController : ControllerBase
	{
		IBookRepository _bookRepository;

		public BookController(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetBooks()
		{
			var books = await _bookRepository.Get();
			if (books == null)
			{
				return NotFound();
			}
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookById(int id)
		{
			var book = await _bookRepository.GetById(id);
			if (book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}

		[HttpPost]
		public async Task<IActionResult> AddBook([FromBody]Book book)
		{
			var result = await _bookRepository.Add(book);
			if (result == null)
			{
				return Content("Book Not Added !");
			}
			return CreatedAtAction(nameof(GetBookById), new { id = result.Id}, $"Book created with ID:{result.Id}");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
		{
			var result = await _bookRepository.Update(id, book);
			if (result == null)
			{
				return Content("Book Not Updated !");
			}
			return Ok($"Book updated with ID:{result.Id}");
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> PatchBook(int id, [FromBody] JsonPatchDocument<Book> book)
		{
			var result = await _bookRepository.Patch(id, book);
			if (!result)
			{
				return Content("Book Not Patched !");
			}
			return Ok($"Book patched with ID:{id}");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook(int id)
		{
			var result = await _bookRepository.Delete(id);
			if (result == null)
			{
				return Content("Book Not Deleted !");
			}
			return Ok($"Book deleted with ID:{result.Id}");
		}
	}
}
