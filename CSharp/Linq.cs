//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace CSharp
//{
//    public class Linq
//    {
//        //        static void Main()
//        //        {
//        //            IList<Employee> employees = new List<Employee>
//        //            {
//        //                new Employee(101, "Steve", "Rogers", 15000, 15),
//        //                new Employee(102, "Tony", "Stark", 35000, 8),
//        //                new Employee(103, "Thor", "Odinson", 18000, 20)
//        //            };

//        //            Console.WriteLine("------Linq------");

//        //            var filteredEmployees = from emp in employees where emp.Salary > 20000 select $"#{emp.Id} {emp.LastName}";

//        //            var fEmp = employees.Where(emp => emp.Salary < 20000);

//        //            foreach (var emp in filteredEmployees)
//        //            {
//        //                Console.WriteLine(emp);
//        //            }

//        //            Console.ReadLine();
//        //        }
//        //    }

//        //    public class Employee
//        //    {
//        //        public int Id { get; set; }
//        //        public string FirstName { get; set; }
//        //        public string LastName { get; set; }
//        //        public decimal Salary { get; set; }
//        //        public int Experience { get; set; }

//        //        public Employee(int id, string firstName, string lastName, decimal salary, int experience)
//        //        {
//        //            Id = id;
//        //            FirstName = firstName;
//        //            LastName = lastName;
//        //            Salary = salary;
//        //            Experience = experience;
//        //        }


//        // LINQ (LINQ to DataSets & LINQ to DataTables completed in ADO .NET project)
//        class Student
//        {
//            public int Id;
//            public string Name;

//            public Student(int id, string name)
//            {
//                Id = id;
//                Name = name;
//            }
//        }

//        static void Main()
//        {
//            //LINQ to Objects
//            int[] arr = new int[] { 25, 16, 33, 82, 31, 54, 21, 78, 53, 93, 82, 12, 32, 13, 43 };

//            List<Student> list = new List<Student>()
//            {
//                new Student(1, "Steven"),
//                new Student(2, "Adam"),
//                new Student(3, "Tim"),
//                new Student(2, "Peter"),
//                new Student(4, "Luis"),
//                new Student(1, "Lucius"),
//                new Student(4, "Bilbo"),
//                new Student(1, "Baggins"),
//                new Student(5, "Natalie"),
//                new Student(1, "Yusuf"),
//            };

//            // OrderBy
//            var newList = from stu in list orderby stu.Id, stu.Name select new { stu.Id, stu.Name };

//            foreach (var a in newList)
//            {
//                Console.WriteLine($"Course Id: {a.Id} - {a.Name}");
//            }


//            //GroupBy
//           var courses = from stu in list group stu by stu.Id;

//            foreach (var course in courses)
//            {
//                Console.WriteLine($"\nCourse Id: {course.Key}\n=======================Z");
//                foreach (var stu in course)
//                {
//                    Console.WriteLine(stu.Name);
//                }
//            }

//            // LINQ TO XML

//            // Test.xml
//            StringBuilder result = new StringBuilder();

//            // Load xml
//            XDocument xdoc = XDocument.Load("C:\\Users\\Family\\source\\repos\\Learning-DotNet\\CSharp\\Test.xml");

//            // Run query
//            var lv1s = from lv1 in xdoc.Descendants("level1")
//                       select new
//                       {
//                           Header = lv1.Attribute("name").Value,
//                           Children = lv1.Descendants("level2")
//                       };

//            // Loop through results
//            Console.WriteLine("==========CUSTOMER XML DATA===========");
//            foreach (var lv1 in lv1s)
//            {
//                result.AppendLine(lv1.Header);
//                foreach (var lv2 in lv1.Children)
//                    result.AppendLine("     " + lv2.Attribute("name").Value);
//            }

//            Console.WriteLine(result);


//            // Customer.xml
//            StringBuilder result1 = new StringBuilder();

//            // Load xml
//            XDocument xdoc1 = XDocument.Load("C:\\Users\\Family\\Source\\Repos\\Learning-DotNet\\CSharp\\Customers.xml");

//            // Run query
//            var customers = from customer in xdoc1.Descendants("Customer")
//                            where customer.Element("Document").Value == "000 000 002"
//                            select new
//                            {
//                                Children = customer.Descendants()
//                            };

//            // Loop through results
//            foreach (var customer in customers)
//            {
//                result1.AppendLine("==========CUSTOMER XML DATA===========");
//                foreach (var details in customer.Children)
//                    result1.AppendLine(details.Name + "     " + details.Value);
//            }

//            Console.WriteLine(result1);

//            Console.ReadLine();
//        }
//    }
//}