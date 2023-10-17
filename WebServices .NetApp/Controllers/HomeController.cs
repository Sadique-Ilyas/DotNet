using System;
using System.Linq;
using System.Web.Mvc;
using WebServices.NetApp.Models;
using WebServices.NetApp.LocalServiceReference;

namespace WebServices.NetApp.Controllers
{
	public class HomeController : Controller
	{
		private WebService1SoapClient _soapClient;
		SessionResponse response = new SessionResponse();

		public HomeController()
		{
			// Basic Http Binding in the code. Instead of adding it in the Web.config file
			//var binding = new BasicHttpBinding()
			//{
			//	Name = "WebService1Soap",
			//	MaxBufferSize = 2147483647,
			//	MaxReceivedMessageSize = 2147483647
			//};

			//var endpoint = new EndpointAddress("http://localhost:65041/WebService1.asmx");
			//_soapClient = new WebService1SoapClient(binding, endpoint);

			_soapClient = new WebService1SoapClient("WebService1Soap");
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Employee()
		{	
			var employees = _soapClient.GetAllEmployeesAsync().Result.ToList();

			return View(employees);
		}

		public ActionResult Calculator()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Calculator(Calculation calculation)
		{
			if (calculation.Operation != null)
			{
				string result = _soapClient.CalculationAsync(calculation.FirstNumber, calculation.Operation, calculation.SecondNumber).Result;
				calculation.Result = result;
			}

			return View(calculation);
		}

		public ActionResult SessionName(SessionResponse response)
		{
			response.SessionNamesList = _soapClient.GetSessionName().ToList();
			response.Count = _soapClient.GetSessionCount();
			return View(response);
		}

		public ActionResult GetSessionName(string sessionName)
		{
			if (sessionName != null && sessionName != string.Empty)
			{
				response.Result = _soapClient.AddSessionName(sessionName);
			}

			return RedirectToAction("SessionName", response);
		}

		public ActionResult IncrementCount()
		{
			_soapClient.IncrementSessionCount();
			return RedirectToAction("SessionName");
		}

 
		/*
		 TimeOut Exception Handling
		 ==============================
		 System.TimeoutException: 'The request channel timed out while waiting for a reply after 00:00:59.7571493.
		 Increase the timeout value passed to the call to Request or increase the SendTimeout value on the Binding.
		 The time allotted to this operation may have been a portion of a longer timeout.'

		 Exception won't be raised because sendTimeout and receiveTimeout value on the binding has been increased to 10 mins
		*/
		public ActionResult TimeOutMethod()
		{
			try
			{
				TempData["message"] = _soapClient.TimeOutMethod();
			}
			catch(Exception ex)
			{
				TempData["message"] = "Request Timed Out !";
			}
			return RedirectToAction("Index");
		}

		// Authentication
		public ActionResult AuthMethod()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AuthMethod(string Username, string Password)
		{
			AuthResponse authResult = _soapClient.AuthMethod(new WebServiceAuth { Username = Username, Password = Password });
			return View(authResult);
		}

		// Token Authentication
		public ActionResult TokenAuthMethod()
		{
			return View();
		}

		[HttpPost]
		public ActionResult TokenAuthMethod(string Username, string Password, string Token=null)
		{
			if (Token == null)
			{
				AuthResponse authResult = _soapClient.TokenAuthMethod(new WebServiceAuth { Username = Username, Password = Password });
				return View(authResult);
			}
			else
			{
				AuthResponse authResult = _soapClient.ValidateToken(new WebServiceAuth { Token = Token });
				return View(authResult);
			}
		}

		public ActionResult EncryptDecryptMethod()
		{
			return View();
		}

		[HttpPost]
		public ActionResult EncryptDecryptMethod(string Username, string Password)
		{
			string encryptedPassword = Security.Base64Encode(Password);
			AuthResponse response = _soapClient.EncryptDecryptMethod(new WebServiceAuth() { Username = Username, Password = encryptedPassword });
			return View(response);
		}

		public ActionResult JsAjaxMethod()
		{
			return View();
		}
	}
}