using BookStore.API.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.API.Repository
{
	public interface IBookRepository
	{
		Task<List<Book>> Get();
		Task<Book> GetById(int id);
		Task<Book> Add(Book book);
		Task<Book> Update(int id, Book book);
		Task<bool> Patch(int id, JsonPatchDocument<Book> book);
		Task<Book> Delete(int id);
	}
}