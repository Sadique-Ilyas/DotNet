//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CSharp
//{
//    public class Threads
//    {
//        // Thread Example
//        static void Main()
//        {
//            Thread t1 = new Thread(new ThreadStart(Thread1Display));
//            Thread t2 = new Thread(new ThreadStart(Thread2Display));
//            t1.Start();
//            t2.Start();
//            Console.WriteLine("Hello from Main Thread => " + Thread.CurrentThread.ManagedThreadId);
//        }

//        public static void Thread1Display()
//        {
//            for (int i = 1; i <= 100; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("Hello from Thread 1 => " + Thread.CurrentThread.ManagedThreadId);
//            }
//        }

//        public static void Thread2Display()
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                Thread.Sleep(5000);
//                Console.WriteLine("Hello from Thread 2 => " + Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//    }
//}
