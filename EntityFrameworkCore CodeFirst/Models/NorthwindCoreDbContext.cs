using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_CodeFirst.Models
{
	public class NorthwindCoreDbContext : DbContext
	{
		public NorthwindCoreDbContext(DbContextOptions options) : base(options)
		{
		}

		DbSet<Product> Product { get; set; }
		DbSet<Category> Category { get; set; }
	}
}
