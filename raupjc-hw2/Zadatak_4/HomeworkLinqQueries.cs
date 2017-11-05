using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1;

namespace Zadatak_4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray) => intArray.GroupBy(i => i)
            .Select(x => $"Broj {x.Key} ponavlja se {x.Count()} puta")
            .OrderBy(i => i)
            .ToArray();

        public static University[] Linq2_1(University[] universityArray) =>
            universityArray.Where(s => s.Students.Count(e => e.Gender.Equals(Gender.Male)).Equals(s.Students.Length))
                .ToArray();

        public static University[] Linq2_2(University[] universityArray) =>
            universityArray.Where(u => u.Students.Length < universityArray.Average(s => s.Students.Length)).ToArray();

        public static Student[] Linq2_3(University[] universityArray) =>
            universityArray.SelectMany(u => u.Students).Distinct().ToArray();

        public static Student[] Linq2_4(University[] universityArray) =>
            universityArray.Where(u =>
                    (u.Students.All(s => s.Gender == Gender.Male) || u.Students.All(s => s.Gender == Gender.Female)))
                .SelectMany(u => u.Students)
                .Distinct()
                .ToArray();

        public static Student[] Linq2_5(University[] universityArray) =>
            universityArray.SelectMany(u => u.Students)
                .GroupBy(s => s)
                .Where(t => t.Count() >= 2)
                .Select(t => t.Key)
                .Distinct()
                .ToArray();
    }
}
