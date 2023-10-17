using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_.NetCore.Models;
using WebApi_.NetCore.Repository;

namespace WebApi_.NetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		//IProductRepository _productRepository;
		//IProductRepository _productRepository2;

		//public ProductController(IProductRepository productRepository, IProductRepository productRepository2)
		//{
		//	_productRepository = productRepository;
		//	_productRepository2 = productRepository2;
		//}

		//[HttpPost]
		//public IActionResult Add([FromBody] Product product)
		//{
		//	_productRepository.AddProduct(product);
		//	var products = _productRepository2.GetProducts();
		//	return Ok(products);
		//}

		//[HttpPost]
		//public IActionResult Add([FromBody] Product product, [FromServices] IProductRepository _productRepository)
		//{
		//	_productRepository.AddProduct(product);
		//	var products = _productRepository.GetProducts();
		//	return Ok(products);
		//}

		[HttpGet]
		public string GetName([FromServices] IProductRepository _productRepository)
		{
			return _productRepository.GetRepoName();
		}
	}
}