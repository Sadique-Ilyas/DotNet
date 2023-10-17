using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.NetApp.Models
{
	public class SessionResponse
	{
		public List<string> SessionNamesList { get; set; }
		public string Result { get; set; }
		public int Count { get; set; }
	}
}