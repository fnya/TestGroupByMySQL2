using System;
using System.Linq;
using TestGroupByMySQL2.Models;

namespace TestGroupByMySQL2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new MyContext())
            {
                var query = db.Result
                    .GroupBy(x => x.Name)
                    .Select(x => new {Name = x.Key, Sum = x.Sum(y => y.Point)});

                foreach(var result in query)
                {
                    Console.WriteLine($"{result.Name}:{result.Sum}");
                }
            }
        }
    }
}