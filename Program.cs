using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionsLambdaDelegateLINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Entities.Product> products = new()
            {
                new Entities.Product("Lapis", 10),
                new Entities.Product("Aula", 45.22),
                new Entities.Product("TV", 912.88),
                new Entities.Product("Tablet", 44.87),
                new Entities.Product("Boia", 0.65),
                new Entities.Product("www", 19392.650)
            };


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
