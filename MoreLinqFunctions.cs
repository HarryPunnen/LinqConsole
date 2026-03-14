using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    internal class MoreLinqFunctions
    {
        //Data Source
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<string> Collection1 = new List<string> {"One","Two", "Three", "Four", "Three" };
        List<string> Collection2 = new List<string> { "Five", "Six", "One", "Six", "Three" };

        public void SetOperators()
        { 
            // Distinct list
            IEnumerable<string> dList = Collection1.Distinct();
           // List<string> dList = Collection1.Skip(1).Distinct().ToList();
            Console.WriteLine("\nDisinct List");
            foreach (var nums in dList)
                Console.Write($"{nums} ");
            // Except list
            dList = Collection1.Except(Collection2).ToList();
            Console.WriteLine("\nExcept List");
            foreach (var nums in dList)
                Console.Write($"{nums} ");

            // Intersect list
            dList = Collection1.Intersect(Collection2);
            Console.WriteLine("\nIntersect List");
            foreach (var nums in dList)
                Console.Write($"{nums} ");

            // Union list
            dList = Collection1.Union(Collection2);
            Console.WriteLine("\nUnion List");
            foreach (var nums in dList)
                Console.Write($"{nums} ");
        }
        public void SkipFunctions()
        { 
            Console.WriteLine("Original list");
            foreach (var num in numbers)
                Console.Write($"{num} ");

            // Skip top 2
            List<int> slist = numbers.Skip(2).ToList();
            Console.WriteLine("\nList after skipping top 2");
            foreach (int num in slist)
                Console.Write($"{num} ");

            slist = numbers.Skip(2).Take(5).ToList();
            //slist = numbers.Take(5).Skip(2).ToList();
            Console.WriteLine("\nList after skipping top 2, and taking only the next 5");
            foreach (int num in slist)
                Console.Write($"{num} ");

            //Skip Numbers which are less than 5 using SkipWhile Method
            //Using Method Syntax
            IEnumerable<int> ResultMS = numbers.SkipWhile(num => num < 5); //.ToList();
            //Accessing the Result using Foreach Loop
            Console.WriteLine($"\nList of numbers > 5 from MS:");
            foreach (var num in ResultMS)
                Console.Write($"{num} ");

            //Using Query Syntax
            List<int> ResultQS = (from num in numbers
                                  select num).SkipWhile(num => num < 5).ToList();
            Console.WriteLine($"\nList of numbers > 5: from QS");
            foreach (var num in ResultQS)
                Console.Write($"{num} ");

            slist = numbers.Skip(2).TakeWhile(num => num < 6).ToList();
            Console.WriteLine("\nList after skipping top 2, and taking only next integers");
            foreach (int num in slist)
                Console.Write($"{num} ");
        }
        // Perform Pagination
        public void Pagination()
        {
            // Demonstration of pagination
        }
    }
}
