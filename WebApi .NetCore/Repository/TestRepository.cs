using WebApi_.NetCore.Models;

namespace WebApi_.NetCore.Repository
{
	public class TestRepository : IProductRepository
	{
		public void AddProduct(Product product)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetProducts()
		{
			throw new NotImplementedException();
		}

		public string GetRepoName()
		{
			return "Hello from TestRepository";
		}
	}
}
