using WebApi_.NetCore.Models;

namespace WebApi_.NetCore.Repository
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> products;
		public ProductRepository()
		{
			products = new List<Product>();
		}

		public void AddProduct(Product product)
		{
			product.Id = products.Count() + 1;
			products.Add(product);
		}

		public List<Product> GetProducts()
		{
			return products;
		}

		public string GetRepoName()
		{
			return "Hello from ProductRepository";
		}
	}
}
