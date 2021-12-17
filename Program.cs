using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionsLambdaDelegateLINQ
{
    using Demos;
    using Entities;
    using global::Demos;

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


            Linq.Init(products);

            ///Referecia simples de metodo com parametro
            // products.Sort(CompareProducts);



            Comparison<Entities.Product> comparer = CompareProducts;
            products.Sort(comparer);


            ///Em programação funcional, expressão lambda corresponde a uma função anônima de primeira classe.
            ///Referenca lambda inline
            //  products.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));



            ///ChamandA 1 via Delegate
            Action<Entities.Product> act = UpdatePrices;
            //products.ForEach(act);


            ///Chamanda 2 diretamente a funcção
            products.ForEach(UpdatePrices);



            /// CHAMADA 1 - VIA DELEGATE
            Func<Entities.Product, string> fn = p => p.Name.ToUpper(); // OU NameUpper;
            products.Select(fn);


            /// CHAMANDA 2 - CHAMANDO DIRETAMENTE O METODO
            products.Select(NameUpper);


            /// CHAMANDA 3 - INLINE
            products.Select((p) => p.Name.ToUpper());








            foreach (var item in products)
                Console.WriteLine(item);


            Console.ReadKey();




        }

        static int CompareProducts(Entities.Product p1, Entities.Product p2)
            => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());



        static void UpdatePrices(Entities.Product p)
            => p.Price += p.Price * 0.5;

        static string NameUpper(Entities.Product p)
            => p.Name.ToUpper();



    }
}
