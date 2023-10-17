using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.NetApp.Models
{
	public class Calculation
	{
		public int FirstNumber { get; set; }
		public string Operation { get; set; }
		public int SecondNumber { get; set; }
		public string Result { get; set; }
	}
}