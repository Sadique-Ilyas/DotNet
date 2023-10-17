using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services
{
	public class WebServiceAuth: System.Web.Services.Protocols.SoapHeader
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }

		public bool ValidateCredentials()
		{
			if(Username == "admin" && Password == "admin@123")
			{
				return true;
			}
			return false;
		}

		public bool ValidateToken()
		{
			if(!string.IsNullOrEmpty(Token))
			{
				return HttpRuntime.Cache[Token] != null;
			}

			return false;
		}
	}
}