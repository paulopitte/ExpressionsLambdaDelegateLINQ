using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos
{
    using Entities;

    public class Linq : DemoBase
    {

        public override void Init(List<Product> products)
        {
            Func<Product, bool> fn = (p) => p.Category.Tier == 1 && p.Price < 900.0;
            var r0 = products.Where(fn);
            //var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("PRODUTOS TIPO  1 E PRIÇO MENOR QUE 900:", r0);



            //Exibe somente os nomes de categorias tools
            Func<Product, bool> fnR2 = p => p.Category.Name.Equals("Tools");
            var r2 = products.Where(fnR2).Select(p => p.Name);
            Print("Produtos somente Categoria Tools", r2);




            var r3 = products.Where(p => p.Name[0] == 'C')
                .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);


            var r4 = products.Where(p => p.Category.Tier == 1)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ThenByDescending(P =>P.Id);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);



            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);
            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or default test1: " + r8);
            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or default test2: " + r9);
            Console.WriteLine();

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max price: " + r10);
            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min price: " + r11);
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r12);
            
            var r13 = products.Where(p => p.Category.Id == 1)
                .Average(p => p.Price);
            Console.WriteLine("Category 1 Average prices: " + r13);
            
            var r14 = products.Where(p => p.Category.Id == 5)
                .Select(p => p.Price)
                .DefaultIfEmpty(0.0) // PROTEÇÃO CASA O SELECT NAO RETORNE NADA
                .Average();
            Console.WriteLine("Category 5 Average prices: " + r14);


            var r15 = products.Where(p => p.Category.Id == 1)
                .Select(p => p.Price)
                .Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Category 1 aggregate sum: " + r15);
            
            Console.WriteLine();

            var r16 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }

    }
}
