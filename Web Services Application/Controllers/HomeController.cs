using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.Diagnostics;
using Web_Services_Application.Models;

namespace Web_Services_Application.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private WebService1SoapClient _soapClient;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			_soapClient = new WebService1SoapClient(WebService1SoapClient.EndpointConfiguration.WebService1Soap);

			var employees = _soapClient.GetAllEmployeesAsync().Result.ToList();

			return View(employees);
		}

		public IActionResult Calculation(Calculation calculation)
		{
			if (calculation.Operation != null)
			{
				_soapClient = new WebService1SoapClient(WebService1SoapClient.EndpointConfiguration.WebService1Soap);
				string result = _soapClient.CalculationAsync(calculation.FirstNumber, calculation.Operation, calculation.SecondNumber).Result;
				calculation.Result = result;
			}

			return View(calculation);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}