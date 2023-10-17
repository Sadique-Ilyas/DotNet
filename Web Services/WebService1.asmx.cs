using System.Collections.Generic;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Threading;
using System.Web;
using System.Web.Caching;

namespace Web_Services
{
	/// <summary>
	/// Summary description for WebService1
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[ScriptService]
	public class WebService1 : WebService
	{
		public WebServiceAuth AuthCredentials;

		[WebMethod]
		public string HelloWorld()
		{
			return "Hello World";
		}

		[WebMethod(MessageName = "MethodOverloading")]
		public string HelloWorld(string name)
		{
			return "Hello " + name;
		}

		[WebMethod]
		public List<Employee> GetAllEmployees()
		{
			string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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

		//[WebMethod]
		//public void GetAllEmployees()
		//{
		//	string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		//	SqlConnection conn = new SqlConnection(connString);
		//	conn.Open();


		//	SqlCommand comm = new SqlCommand("spGetAllEmployees", conn);
		//	comm.CommandType = CommandType.StoredProcedure;

		//	SqlDataReader dataReader = comm.ExecuteReader();

		//	List<Employee> employees = new List<Employee>();
		//	while (dataReader.Read())
		//	{
		//		Employee employee = new Employee(employeeID: Convert.ToInt32(dataReader[0]),
		//										 lastName: dataReader[1].ToString(),
		//										 firstName: dataReader[2].ToString()
		//										 );
		//		employees.Add(employee);
		//	}
		//	conn.Close();

		//	JavaScriptSerializer js = new JavaScriptSerializer();
		//	Context.Response.Write(js.Serialize(new Response(employees)));
		//}


		// Exception Handling
		[WebMethod]
		public string Calculation(int firstNumber, string operation, int secondNumber)
		{
			int result = 0;

			try
			{
				switch (operation)
				{
					case "+": result = firstNumber + secondNumber; break;
					case "-": result = firstNumber - secondNumber; break;
					case "*": result = firstNumber * secondNumber; break;
					case "/": result = firstNumber / secondNumber; break;
					default: return "Invalid Operation";
				}
			}
			catch(Exception ex)
			{
				return ex.Message;
			}

			return result.ToString();
		}

		// Session State
		[WebMethod(EnableSession = true)]
		public string AddSessionName(string name)
		{
			List<string> names;

			if(Session["name"] == null)
			{
				names = new List<string>();
			}
			else
			{
				names = (List<string>)Session["name"];
			}

			names.Add(name);
			Session["name"] = names;

			return string.Format("Added {0} !", name);
		}

		// Session State
		[WebMethod(EnableSession = true)]
		public List<string> GetSessionName()
		{
			List<string> names;

			if (Session["name"] == null)
			{
				names = new List<string>();
				names.Add("No items to display !");
			}
			else
			{
				names = (List<string>)Session["name"];
			}

			return names;
		}

		// Session State
		[WebMethod(EnableSession = true)]
		public void IncrementSessionCount()
		{
			int count = 1;

			if (Session["count"] != null)
			{
				count = (int)Session["count"];
				count++;
			}

			Session["count"] = count;
		}

		// Session State
		[WebMethod(EnableSession = true)]
		public int GetSessionCount()
		{
			int count = 0;

			if (Session["count"] != null)
			{
				count = (int)Session["count"];
			}

			return count;
		}

		// TimeOut Exception Handling
		/*
		 System.TimeoutException: 'The request channel timed out while waiting for a reply after 00:00:59.7571493.
		 Increase the timeout value passed to the call to Request or increase the SendTimeout value on the Binding.
		 The time allotted to this operation may have been a portion of a longer timeout.'

		 */
		[WebMethod]
		public string TimeOutMethod()
		{
			Thread.Sleep(60000); // 1min = 60 * 1000 milliseconds
			return "Wuff !!! It took too long";
		}

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("AuthCredentials", Required = true)]
		public AuthResponse AuthMethod()
		{
			if (AuthCredentials != null)
			{
				if (AuthCredentials.ValidateCredentials())
				{
					return new AuthResponse(username: AuthCredentials.Username, isCredentialsValid: true, message: "Credentials are Valid !");
				}
				else
				{
					return new AuthResponse("Invalid Authentication Credentials !");
				}
			}
			return new AuthResponse("Please provide Authentication Credentials !");
		}

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("AuthCredentials", Required = true)]
		public AuthResponse TokenAuthMethod()
		{
			AuthResponse response = AuthMethod();
			if(!response.IsCredentialsValid)
			{
				return response;
			}

			string token = Guid.NewGuid().ToString();
			HttpRuntime.Cache.Add(token, response.Username, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30), CacheItemPriority.NotRemovable, null);
			AuthCredentials.Token = token;
			response.Token = token;

			return response;
		}

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("AuthCredentials", Required = true)]
		public AuthResponse ValidateToken()
		{
			if(AuthCredentials.ValidateToken())
			{
				return new AuthResponse(token: AuthCredentials.Token, isTokenValid: true, message: "Token is Valid !");
			}
			return new AuthResponse(token: AuthCredentials.Token, message: "Token is not Valid");
		}

		#region EncryptDecrypt

		[WebMethod]
		[System.Web.Services.Protocols.SoapHeader("AuthCredentials", Required = true)]
		public AuthResponse EncryptDecryptMethod()
		{
			if (AuthCredentials != null)
			{
				string username = AuthCredentials.Username;
				string password = AuthCredentials.Password;

				AuthCredentials.Password = Security.Base64Decode(AuthCredentials.Password);

				if (AuthCredentials.ValidateCredentials())
				{
					return new AuthResponse(username: AuthCredentials.Username, isCredentialsValid: true, message: "Credentials are Valid !");
				}
				else
				{
					return new AuthResponse("Invalid Authentication Credentials !");
				}
			}
			return new AuthResponse("Please provide Authentication Credentials !");
		}

		#endregion
	}

	public class AuthResponse
	{
		public string Username { get; set; }
		public bool IsCredentialsValid { get; set; }
		public bool IsTokenValid { get; set; }
		public string Token { get; set; }
		public string Message { get; set; }

		public AuthResponse()
		{
		}

		public AuthResponse(string message, string username=null, bool isCredentialsValid=false, bool isTokenValid = false, string token=null)
		{
			Username = username;
			IsCredentialsValid = isCredentialsValid;
			IsTokenValid = isTokenValid;
			Message = message;
			Token = token;
		}
	}

	public class Response
	{
		public List<Employee> employees;

		public Response(List<Employee> employees)
		{
			this.employees = employees;
		}
	}

	public class Employee
	{
		public int EmployeeID { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }

		public Employee()
		{
		}

		public Employee(int employeeID, string lastName, string firstName)
		{
			EmployeeID = employeeID;
			LastName = lastName;
			FirstName = firstName;
		}
	}
}
