using WebApi_.NetCore.Models;

namespace WebApi_.NetCore.Repository
{
	public interface IProductRepository
	{
		void AddProduct(Product product);
		List<Product> GetProducts();
		public string GetRepoName();
	}
}