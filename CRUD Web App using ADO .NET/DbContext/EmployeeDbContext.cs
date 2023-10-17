using System.Data.SqlClient;
using System.Data;
using CRUD_Web_App_using_ADO_.NET.Models;

namespace CRUD_Web_App_using_ADO_.NET.DbContext
{
	public class EmployeeDbContext : IDbContext<Employee>
	{
		private readonly IConfiguration _configuration;

		public EmployeeDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public List<Employee> GetAll()
		{
			string connString = _configuration.GetConnectionString("DefaultConnection");
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();


			SqlCommand comm = new SqlCommand("spGetAllEmployees", conn);
			comm.CommandType = CommandType.StoredProcedure;

			SqlDataReader dataReader = comm.ExecuteReader();

			List<Employee> employees = new List<Employee>();
			while (dataReader.Read())
			{
				Employee employee = new Employee(employeeID: Convert.ToInt32(dataReader[0]),
												 lastName: dataReader[1].ToString(),
												 firstName: dataReader[2].ToString()
												 );
				employees.Add(employee);
			}

			conn.Close();

			return employees;
		}

		public Employee GetById(int id) 
		{
			string connString = _configuration.GetConnectionString("DefaultConnection");
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();

			string query = "spGetEmployeeById";
			SqlCommand comm = new SqlCommand(query, conn);
			comm.CommandType = CommandType.StoredProcedure;
			comm.Parameters.AddWithValue("@id", id);
			SqlDataReader reader = comm.ExecuteReader();

			Employee employee = new Employee();
			if (reader.Read())
			{
				employee = new Employee(employeeID: Convert.ToInt32(reader[0]), lastName: reader[1].ToString(), firstName: reader[2].ToString());
			}
			conn.Close();

			return employee;
		}

		public bool Add(Employee employee)
		{
			string connString = _configuration.GetConnectionString("DefaultConnection");
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();

			SqlCommand comm = new SqlCommand("spAddEmployee", conn);
			comm.CommandType = CommandType.StoredProcedure;
			comm.Parameters.AddWithValue("@LastName", employee.LastName);
			comm.Parameters.AddWithValue("@FirstName", employee.FirstName);

			int rows = comm.ExecuteNonQuery();
			if (rows > 0) return true;

			conn.Close();

			return false;
		}

		public bool Update(Employee employee)
		{
			string connString = _configuration.GetConnectionString("DefaultConnection");
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();

			SqlCommand comm = new SqlCommand("spUpdateEmployee", conn);
			comm.CommandType = CommandType.StoredProcedure;
			comm.Parameters.AddWithValue("@EmpId", employee.EmployeeID);
			comm.Parameters.AddWithValue("@LastName", employee.LastName);
			comm.Parameters.AddWithValue("@FirstName", employee.FirstName);

			int rows = comm.ExecuteNonQuery();
			if (rows > 0) return true;

			conn.Close();

			return false;
		}

		public bool Delete(Employee employee)
		{
			string connString = _configuration.GetConnectionString("DefaultConnection");
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();

			SqlCommand comm = new SqlCommand("spDeleteEmployee", conn);
			comm.CommandType = CommandType.StoredProcedure;
			comm.Parameters.AddWithValue("@EmpId", employee.EmployeeID);

			int rows = comm.ExecuteNonQuery();
			if (rows > 0) return true;

			conn.Close();

			return false;
		}
	}
}
