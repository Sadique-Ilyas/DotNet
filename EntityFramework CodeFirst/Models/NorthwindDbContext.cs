using System.Data.Entity;

namespace EntityFramework_CodeFirst.Models
{
	public class NorthwindDbContext : DbContext
	{
		public NorthwindDbContext() : base("Data Source=.;Initial Catalog=NorthwindDB;Integrated Security=True") 
		{
		}

		public DbSet<Product> Product {  get; set; }
		public DbSet<Category> Category { get; set; }
	}
}
