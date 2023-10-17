using System.Diagnostics;
using EntityFramework_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		NorthwindDbContext _context = new NorthwindDbContext();

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			//var products = _context.Product.Where(product => product.Price > 25000).ToList();
			var products = from product in _context.Product where product.Price > 25000 select product;
			return View(products);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}