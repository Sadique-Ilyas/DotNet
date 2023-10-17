using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace CSharp
{
	public class Program
	{
		// Thread Example

		//static void Main()
		//{
		//    Thread t1 = new Thread(new ThreadStart(Thread1Display));
		//    Thread t2 = new Thread(new ThreadStart(Thread2Display));
		//    t1.Start();
		//    t2.Start();
		//    Console.WriteLine("Hello from Main Thread => " + Thread.CurrentThread.ManagedThreadId);
		//}

		//public static void Thread1Display()
		//{
		//    for (int i = 1; i <= 100; i++)
		//    {
		//        Thread.Sleep(1000);
		//        Console.WriteLine("Hello from Thread 1 => " + Thread.CurrentThread.ManagedThreadId);
		//    }
		//}

		//public static void Thread2Display()
		//{
		//    for (int i = 1; i <= 10; i++)
		//    {
		//        Thread.Sleep(5000);
		//        Console.WriteLine("Hello from Thread 2 => " + Thread.CurrentThread.ManagedThreadId);
		//    }
		//}


		// Delegates, MultiCasting, Events Example

		//static void Main()
		//{
		//    SenderClass senderClass = new SenderClass();
		//    senderClass.sender = Receiver;
		//    Thread thread = new Thread(new ThreadStart(senderClass.Process));
		//    thread.Start();
		//    Console.WriteLine("Main()");
		//}

		//public static void Receiver(int i)
		//{
		//    Console.WriteLine(i);
		//}

		//class SenderClass
		//{
		//    public delegate void Sender(int i);
		//    public Sender sender = null;
		//    public void Process()
		//    {
		//        for (int i = 1; i <= 100; i++)
		//        {
		//            Thread.Sleep(1000);
		//            sender(i);
		//        }
		//    }
		//}




		// LINQ (LINQ to DataSets & LINQ to DataTables completed in ADO .NET project)

		//class Student
		//{
		//    public int Id;
		//    public string Name;

		//    public Student(int id, string name)
		//    {
		//        Id = id;
		//        Name = name;
		//    }
		//}

		//static void Main()
		//{
		//    LINQ to Objects
		//    int[] arr = new int[] { 25, 16, 33, 82, 31, 54, 21, 78, 53, 93, 82, 12, 32, 13, 43 };

		//    List<Student> list = new List<Student>() 
		//    {
		//        new Student(1, "Steven"),
		//        new Student(2, "Adam"),
		//        new Student(3, "Tim"),
		//        new Student(2, "Peter"),
		//        new Student(4, "Luis"),
		//        new Student(1, "Lucius"),
		//        new Student(4, "Bilbo"),
		//        new Student(1, "Baggins"),
		//        new Student(5, "Natalie"),
		//        new Student(1, "Yusuf"),
		//    };

		//    // OrderBy
		//    var newList = from stu in list orderby stu.Id, stu.Name select new { stu.Id, stu.Name };

		//    foreach (var a in newList)
		//    {
		//        Console.WriteLine($"Course Id: {a.Id} - {a.Name}");
		//    }


		// GroupBy
		//var courses = from stu in list group stu by stu.Id;

		//foreach ( var course in courses)
		//{
		//    Console.WriteLine($"\nCourse Id: {course.Key}\n=======================Z");
		//    foreach(var stu in course)
		//    {
		//        Console.WriteLine(stu.Name);
		//    }
		//}
		//}

		// LINQ TO XML
		static void Main()
		{
			//StringBuilder result = new StringBuilder();

			////Load xml
			//XDocument xdoc = XDocument.Load("C:\\Users\\Family\\source\\repos\\DotNet\\CSharp\\Test.xml");

			////Run query
			//var lv1s = from lv1 in xdoc.Descendants("level1")
			//		   select new
			//		   {
			//			   Header = lv1.Attribute("name").Value,
			//			   Children = lv1.Descendants("level2")
			//		   };

			////Loop through results
			//foreach (var lv1 in lv1s)
			//{
			//	result.AppendLine(lv1.Header);
			//	foreach (var lv2 in lv1.Children)
			//		result.AppendLine("     " + lv2.Attribute("name").Value);
			//}

			//Console.WriteLine(result);

			//Console.ReadLine();

			StringBuilder result = new StringBuilder();

			//Load xml
			XDocument xdoc = XDocument.Load("C:\\Users\\Family\\source\\repos\\DotNet\\CSharp\\Customers.xml");

			//Run query
			var customers = from customer in xdoc.Descendants("Customer")
							where customer.Element("Document").Value == "000 000 002"
							select new
							{
								Children = customer.Descendants()
							};

			//Loop through results
			foreach (var customer in customers)
			{
				result.AppendLine("========================");
				foreach (var details in customer.Children)
					result.AppendLine(details.Name + "     " + details.Value);
			}

			Console.WriteLine(result);

			Console.ReadLine();
		}
	}
}




//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.Serialization;
//using System.Text.RegularExpressions;
//using System.Text;
//using System;



//class Result
//{
//	public static string getPhoneNumber(string s)
//	{
//		string[] wordsArray = s.Split(' ');
//		string number = "";
//		string times = "";

//		foreach (var word in wordsArray)
//		{
//			switch (word)
//			{
//				case "double":
//					times = "double";
//					break;
//				case "triple":
//					times = "triple";
//					break;
//				default:
//					if (times == "double")
//					{
//						for (int i = 1; i <= 2; i++)
//						{
//							number += Result.AddNumber(word);
//						}
//						times = "";
//					}
//					else if (times == "triple")
//					{
//						for (int i = 1; i <= 3; i++)
//						{
//							number += Result.AddNumber(word);
//						}
//						times = "";
//					}
//					else
//					{
//						number += Result.AddNumber(word);
//					}
//					break;
//			}
//		}

//		return number;
//	}

//	public static string AddNumber(string word)
//	{
//		switch (word)
//		{
//			case "one": return "1"; 
//			case "two": return "2"; 
//			case "three": return "3";
//			case "four": return "4";
//			case "five": return "5";
//			case "six": return "6";
//			case "seven": return "7";	
//			case "eight": return "8";
//			case "nine": return "9";
//			case "zero": return "0";
//		}
//		return "";
//	}
//}

//class Program
//{
//	public static void Main(string[] args)
//	{
//		Console.WriteLine("Enter phone number in words");
//		string s = Console.ReadLine();
//		//string s = "six two double zero one seven two eight four one";

//		string result = Result.getPhoneNumber(s);

//		Console.WriteLine(result);

//		Console.Read();
//	}
//}
