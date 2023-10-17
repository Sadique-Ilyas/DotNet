using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_.NetCore.Models;

namespace WebApi_.NetCore.Controllers
{
	[ApiController]
	//[Route("/")]
	//[Route("api")]
	//[Route("api/[controller]")]
	[Route("api/[controller]")]
	//[Route("api/v1/[controller]/[action]")]
	public class EmployeesController : ControllerBase
	{
		private List<Employee> employees;

		public EmployeesController()
		{
			employees = new List<Employee>()
			{
				new Employee()
				{
					Id = 1,
					Name = "Steve Rogers"
				},
				new Employee()
				{
					Id = 2,
					Name = "Tony Stark"
				},
				new Employee()
				{
					Id = 3,
					Name = "Thor Odinson"
				}
			};
		}

		// Routing

		//public string Get()
		//{
		//	return "Hello Employee !";
		//}

		//[Route("Get1")]
		//public string Get1()
		//{
		//	return "Hello Employee 1 !";
		//}

		//[Route("Get2")]
		//public string Get2()
		//{
		//	return "Hello Employee 2 !";
		//}

		//[Route("~/Get3")] // => https://localhost:44324/Get3
		//public string Get3()
		//{
		//	return "Hello Employee 3 !";
		//}

		//[HttpGet]
		//public List<Employee> Get()
		//{
		//	return employees;
		//}

		//[HttpGet("{id}")]
		//public Employee GetById(int id)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Id == id);
		//	return employee;
		//}

		// Route Variables type can be int, string(default), bool, double, float, datetime etc.
		//[HttpGet("{id:int}")]
		//public Employee GetById(int id)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Id == id);
		//	return employee;
		//}

		//[HttpGet("{name}")]
		//public Employee GetByName(string name)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Name.Contains(name));
		//	return employee;
		//}

		// Route variable constraints can be min(number), max(number), minlength(10), maxlength(10), length(10), range(10, 15), alpha=>only alphabetical character, required, regex(expression)
		//[HttpGet("{id:int:max(3)}")]
		//public Employee GetById(int id)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Id == id);
		//	return employee;
		//}

		//[HttpGet("{id:int:range(1,4)}")]
		//public Employee GetById(int id)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Id == id);
		//	return employee;
		//}

		//[HttpGet("{name:minlength(3)}")]
		//public Employee GetByName(string name)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Name.Contains(name));
		//	return employee;
		//}

		//[HttpGet("{name:regex(T*(y|r))}")]
		//public Employee GetByName(string name)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Name.Contains(name));
		//	return employee;
		//}

		//[HttpGet("{id:int}")]
		//public IActionResult GetById(int id)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Id == id);
		//	if (employee == null)
		//	{
		//		return NotFound();
		//	}
		//	return Ok(employee);
		//}

		//[HttpGet("{id:int}")]
		//public ActionResult<Employee> GetById(int id)
		//{
		//	var employee = employees.FirstOrDefault(x => x.Id == id);
		//	if (employee == null)
		//	{
		//		return NotFound();
		//	}
		//	return employee;
		//}

		//[HttpGet()] // Pass JSON in body like { "Id": "123", "Name":"Barry Allen" }
		//public string Post(Employee employee)
		//{
		//	return $"Id: {employee.Id} - Name: {employee.Name} ";
		//}

		//[HttpPost]
		//public string Post()
		//{
		//	return "Hello from Post() method";
		//}

		//[HttpPost]
		//public string Post()
		//{
		//	return "Hello from Post() method";
		//}

		//[HttpPost("{id}/{name}")]
		//public string Post(int id, string name)
		//{
		//	return $"Id: {id} - Name: {name} ";
		//}

		//[HttpPost()] // => https://localhost:44324/api/v1/employees?id=4&name=Bruce
		//public string Post(int id, string name)
		//{
		//	return $"Id: {id} - Name: {name} ";
		//}

		//[HttpPost()] // Pass JSON in body like { "Id": "4", "Name":"Bruce Banner" }
		//public string Post(Employee employee)
		//{
		//	return $"Id: {employee.Id} - Name: {employee.Name} ";
		//}

		//[HttpPost()]
		//public IActionResult Post(Employee employee)
		//{
		//	employees.Add(employee);
		//	return CreatedAtAction("GetById", new { id = employee.Id }, employee);
		//}
	}
}