//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSharp
//{
//    public class ExtensionMethods
//    {
//        static void Main()
//        {
//            Console.WriteLine("--------Extension Methods---------");

//            string str = "Hello world!";

//            Console.WriteLine(str.Length);
//            Console.WriteLine(str.IsStringLengthEven());

//            Console.ReadLine();
//        }
//    }

//    public static class StringExtension
//    {
//        public static bool IsStringLengthEven(this string str)
//        {
//            if (str.Length % 2 == 0)
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}
