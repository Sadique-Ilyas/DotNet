//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CSharp
//{
//    public class Delegates
//    {
//        public delegate void AddDelegate(int a, int b);
//        public delegate int SubtractDelegate(int a, int b);
//        public delegate void MultiplyDelegate(int a, int b);
//        public delegate decimal DivideDelegate(int a, int b);
//        public delegate bool IsActiveDelegate(int a, int b);

//        public void Add(int a, int b)
//        {
//            Console.WriteLine("Sum: " + (a + b));
//        }

//        public int Subtract(int a, int b)
//        {
//            return a - b;
//        }

//        public static void Multiply(int a, int b)
//        {
//            Console.WriteLine("Product: " + (a * b));
//        }

//        public static decimal Divide(int a, int b)
//        {
//            return a / b;
//        }

//        static void Main()
//        {
//            // Direct Method Invocation (Without Delegates)
//            Console.WriteLine("------Direct Method Invocation (Without Delegates)--------");
//            Delegates delegates = new Delegates();
//            delegates.Add(1, 2);

//            int diff = delegates.Subtract(10, 2);
//            Console.WriteLine("Difference: " + diff);

//            Delegates.Multiply(6, 2);

//            decimal quo = Delegates.Divide(12, 4);
//            Console.WriteLine("Quotient: " + quo);

//            Console.WriteLine();

//            // Method Invocation using Delegates
//            Console.WriteLine("-------Method Invocation using Delegates--------");
//            AddDelegate addDelegate = new AddDelegate(delegates.Add);
//            addDelegate(1, 2);

//            SubtractDelegate subtractDelegate = new SubtractDelegate(delegates.Subtract);
//            int diff1 = subtractDelegate(10, 2);
//            Console.WriteLine("Difference: " + diff);

//            MultiplyDelegate multiplyDelegate = new MultiplyDelegate(Delegates.Multiply);
//            multiplyDelegate(6, 2);

//            DivideDelegate divideDelegate = new DivideDelegate(Delegates.Divide);
//            decimal quo1 = divideDelegate(12, 4);
//            Console.WriteLine("Quotient: " + quo1);

//            Console.WriteLine();

//            // Multicast Delegates
//            Console.WriteLine("------Multicast Delegates--------");
//            AddDelegate addDelegate1 = delegates.Add; // Another way to instantitate delegate
//            addDelegate1 += Delegates.Multiply;

//            addDelegate1.Invoke(5, 4);

//            Console.WriteLine();

//            // Anonymous Methods
//            Console.WriteLine("------Delegates with Anonymous Methods--------");
//            IsActiveDelegate isActiveDelegate = delegate (int x, int y)
//            {
//                return x > y;
//            };
//            bool status = isActiveDelegate(4, 13);
//            Console.WriteLine("Status: " + status);

//            Console.WriteLine();

//            // Lambda Expression
//            Console.WriteLine("------Delegates with Anonymous Methods & Lambda Expression--------");
//            IsActiveDelegate isActiveDelegate1 = (x, y) =>
//            {
//                return x > y;
//            };
//            bool status1 = isActiveDelegate(24, 13);
//            Console.WriteLine("Status: " + status1);

//            Console.WriteLine();

//            // Pre-defined Inbuilt Generic Delegates (Func, Action, Predicate)
//            Console.WriteLine("--------Pre-defined Inbuilt Generic Delegates (Func, Action, Predicate)--------");
//            Func<int, int, int> func = (num1, num2) =>
//            {
//                return num1 + num2;
//            };
//            Console.WriteLine("Sum: " + func(5, 12));

//            Action<string> action = (name) => Console.WriteLine($"Hello {name}");
//            action("Steve");

//            Predicate<int> predicate = (x) =>
//            {
//                return x > 1;
//            };
//            Console.WriteLine("Status: " + predicate(-5));

//            Console.WriteLine();

//            // Real life example with event
//            SenderClass senderClass = new SenderClass();
//            senderClass.sender = Receiver;
//            Thread thread = new Thread(new ThreadStart(senderClass.Process));
//            thread.Start();
//            Console.WriteLine("Main()");


//            Console.ReadLine();
//        }

//        public static void Receiver(int i)
//        {
//            Console.WriteLine(i);
//        }
//    }    

//    class SenderClass
//    {
//        public delegate void Sender(int i);
//        public Sender sender = null;
//        public void Process()
//        {
//            for (int i = 1; i <= 100; i++)
//            {
//                Thread.Sleep(1000);
//                sender(i);
//            }
//        }
//    }
//}