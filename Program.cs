using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionsLambdaDelegateLINQ
{
    using Demos;
    using Entities;

    class Program
    {
        static void Main(string[] args)
        {

            var c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new() { Id = 3, Name = "Electronics", Tier = 1 };

            var products = new List<Product>() {
                new () { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new () { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new () { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new () { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new () { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new () { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new () { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new () { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new () { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new () { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new () { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };


            // new LambdaDelegates().Init(products);

            //new Linq().Init(products);


            Client a = new() { Email = "paulopitte@gmail.com", Name = "PauloPitte" };
            Client b = new() { Email = "paulopitte@gmail.com", Name = "PauloSMPitte" };


            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            Console.ReadKey();




        }


    }
}
