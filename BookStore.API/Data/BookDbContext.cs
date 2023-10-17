using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
	public class BookDbContext: IdentityDbContext<ApplicationUser>
	{
        public BookDbContext(DbContextOptions<BookDbContext> options): base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
