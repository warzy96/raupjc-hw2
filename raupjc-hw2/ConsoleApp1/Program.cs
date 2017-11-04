using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var topStudents1 = new List<Student>()
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
            Console.ReadLine();

        }
    }
}
