using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web_Services
{
	public class Security
	{
		public static string Base64Encode(string Data)
		{
			var dataBytes = Encoding.UTF8.GetBytes(Data);
			return Convert.ToBase64String(dataBytes);
		}

		public static string Base64Decode(string Base64EncodedData)
		{
			var base64EncodedBytes = Convert.FromBase64String(Base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}