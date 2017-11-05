using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Zadatak_1;
using Zadatak_4;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*var topStudents1 = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan1 = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool isIvanTopStudent1 = topStudents1.Contains(ivan1);
            Console.WriteLine(isIvanTopStudent1);

            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
            Console.WriteLine(distinctStudentsCount);


            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            Console.WriteLine(isIvanTopStudent);
            Console.ReadLine();*/

            int[] integers =  {1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5};
            string[] strings = HomeworkLinqQueries.Linq1(integers);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            University uni = new University()
            {
                Name = "prvo",
                Students = new[] { new Student("ivan", "0036495542") {Gender = Gender.Male},
                    new Student("lara", "39845792375") {Gender = Gender.Male},  }
            };
            University uni2 = new University()
            {
                Name = "drugo",
                Students = new[] { new Student("lara", "1234567898") {Gender = Gender.Female} }
            };
            University[] unis = {uni, uni2};
            var maleUni = HomeworkLinqQueries.Linq2_1(unis);
            foreach (var university in maleUni)
            {
                Console.WriteLine(university.Students[0].Gender);
            }


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.Invoke(() =>LongOperation("A"),
                            () =>LongOperation("B"),
                            () =>LongOperation("C"),
                            () =>LongOperation("D"),
                            () =>LongOperation("E"));

            stopwatch.Stop();
            Console.WriteLine("Synchronous long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);


            /*int counter = 0;
            object objectUsedForLock = new object();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                lock (objectUsedForLock)
                {
                    counter += 1;
                }
            });
            Console.WriteLine("Counter should be 100000. Counter is {0}", counter);
            */

            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                iterations.Add(i * i);
            });

            Console.WriteLine("Bag length should be 100000. Length is {0}", iterations.Count);
            Console.ReadLine();
        }

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished. Executing Thread: {1}", taskName, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
