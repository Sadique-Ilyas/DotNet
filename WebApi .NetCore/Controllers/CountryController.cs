using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_.NetCore.Model_Binders;
using WebApi_.NetCore.Models;

namespace WebApi_.NetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[BindProperties(SupportsGet = true)]
	public class CountryController : ControllerBase
	{
		// Model Binding


		//[BindProperty(SupportsGet = true)]
		//public string? Name { get; set; }
		//[BindProperty(SupportsGet = true)]
		//public int Population { get; set; }
		//[BindProperty(SupportsGet = true)]
		//public decimal Area { get; set; }

		[BindProperty(SupportsGet = true)]
		public Country? Country { get; set; }

		//[HttpPost()]
		//public string Post()
		//{
		//	return "Name: " + this.Name;
		//}

		//[HttpGet()]
		//public string Get()
		//{
		//	return $"Name: {this.Country?.Name} | Population: {this.Country?.Population} | Area: {this.Country?.Area}";
		//}

		// Gets name value only from query string
		//[HttpGet("{name}")]
		//public string GetName([FromQuery] string name)
		//{
		//	return $"Name: {name}";
		//}

		//[HttpGet("{name}")]
		//public string GetName([FromRoute] string name)
		//{
		//	return $"Name: {name}";
		//}

		//[HttpGet("{name}")]
		//public string GetName([FromHeader] string name)
		//{
		//	return $"Name: {name}";
		//}

		//[HttpGet("{name}")]
		//public string GetName([FromForm] string name)
		//{
		//	return $"Name: {name}";
		//}

		//[HttpGet("{name}")]
		//public string GetName([FromBody] string name)
		//{
		//	return $"Name: {name}";
		//}

		[HttpGet("search")] // => https://localhost:44324/api/Country/search?countries=India|Japan|USA|China|Spain
		public string[] GetName([ModelBinder(typeof(CustomModelBinder))] string[] countries)
		{
			return countries;
		}
	}
}
