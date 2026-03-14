using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    internal class LinqStudent
    {
        public void SomeLinQ()
        {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            Console.WriteLine("Student List");
            var teenAgeStudents = studentList.Where(s => s.Age > 12 && s.Age < 20)
                                  .ToList<Student>();
            foreach (Student std in teenAgeStudents)
            {
                Console.WriteLine($"{std.StudentName} ,   {std.Age}");
            }
            // method syntax
            var studentsInAscOrder = studentList.Where(s => s.Age > 12 && s.Age < 20)
                                                .OrderBy(s => s.StudentName);
            // Query syntax
            var orderByResult = from s in studentList
                                where s.Age > 12 && s.Age < 25
                                orderby s.StudentName
                                select s;
            Console.WriteLine("\nDesc Ordered Student List");
            foreach (Student std in orderByResult)
            {
                Console.WriteLine($"{std.StudentName} ,   {std.Age}");
            }

            var orderByDescendingResult = from s in studentList
                                          orderby s.StudentName descending
                                          select s;
            Console.WriteLine("\nDescending Order Studentlist\n");
            foreach (var std in orderByDescendingResult)
                Console.WriteLine(std.StudentName);
        }

        public void DelayedExecution()
        {
            // string collection
            IList<string> stringList = new List<string>()
            { "C# Tutorials", "VB.NET Tutorials", "Learn C++", "MVC Tutorials" , "Java" };

            // LINQ Method Syntax
            var result = stringList.Where(s => s.Contains("Tutorials"));

            foreach(var str in result)
                Console.WriteLine(str);
        }

        public void GroupByExecution()
        {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            //GROUP  
            var querySyntax7 = from std in studentList
                               group std by std.Age;

            Console.WriteLine("\nGroup in querySyntax------");
            foreach (var item in querySyntax7)
            {
                Console.WriteLine(item.Key + ":" + item.Count());
                foreach (Student s in item)
                    Console.WriteLine($"Student Id:{s.StudentID}, Name:{s.StudentName}");
            }
            // Use method/query syntax to query for teenagers and retrieve only their name
            // Query syntax
            var orderByResult = from s in studentList
                                where s.Age > 12 && s.Age < 25
                                orderby s.StudentName
                                select s.StudentName;
            foreach (var s in orderByResult)
                Console.WriteLine(s);
        }

    }
}
