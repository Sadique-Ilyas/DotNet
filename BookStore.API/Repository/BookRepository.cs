using BookStore.API.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository
{
	public class BookRepository : IBookRepository
	{
		public BookDbContext _DbContext;

		public BookRepository(BookDbContext dbContext)
		{
			_DbContext = dbContext;
		}

		public async Task<Book> Add(Book book)
		{
			var result = await _DbContext.Books.AddAsync(book);
			await _DbContext.SaveChangesAsync();
			var _book = result.Entity;

			return _book;
		}

		public async Task<List<Book>> Get()
		{
			var books = await _DbContext.Books.ToListAsync();
			return books;
		}

		public async Task<Book> GetById(int id)
		{
			var book = await _DbContext.Books.FindAsync(id);
			return book;
		}

		public async Task<Book> Update(int id, Book book)
		{
			book.Id = id;
			var result = _DbContext.Books.Update(book);
			await _DbContext.SaveChangesAsync();
			var _book = result.Entity;

			return _book;
		}

		public async Task<bool> Patch(int id, JsonPatchDocument<Book> book)
		{
			var _book = await _DbContext.Books.FindAsync(id);
			if (_book != null)
			{
				book.ApplyTo(_book);
				await _DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<Book> Delete(int id)
		{
			var book = new Book { Id = id };
			var result = _DbContext.Books.Remove(book);
			await _DbContext.SaveChangesAsync();
			var _book = result.Entity;

			return _book;
		}
	}
}
