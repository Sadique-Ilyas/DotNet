using System.Data.Entity;

namespace EntityFramework_CodeFirst.Models
{
	public class NorthwindDbContext : DbContext
	{
		public NorthwindDbContext() : base("Data Source=DESKTOP-49NRA9G;Initial Catalog=NorthwindDB;Integrated Security=True") 
		{
		}

		public DbSet<Product> Product {  get; set; }
		public DbSet<Category> Category { get; set; }
	}
}
