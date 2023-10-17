using CRUD_Web_App_using_ADO_.NET.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD_Web_App_using_ADO_.NET.DbContext;

namespace CRUD_Web_App_using_ADO_.NET.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDbContext<Employee> _dbContext;

		public EmployeeController(IDbContext<Employee> dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
        {
            List<Employee> employees = _dbContext.GetAll();
            return View(employees);
        }

		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
		public IActionResult Create(Employee employee)
		{
            if(ModelState.IsValid)
            {
                bool result =  _dbContext.Add(employee);

                if (result) TempData["NotificationMessage"] = "Data Inserted Successfully !";

				return RedirectToAction("Index");
            }
			return View();
		}

		public IActionResult Edit(int id)
		{
            Employee employee = _dbContext.GetById(id);
			return View(employee);
		}

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                bool result = _dbContext.Update(employee);

                if(result) TempData["NotificationMessage"] = "Data Updated Successfully";

				return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
			Employee employee = _dbContext.GetById(id);
			return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            bool result = _dbContext.Delete(employee);

            if(result) TempData["NotificationMessage"] = "Data Deleted Successfully";

			return RedirectToAction("Index");
        }
    }
}
