using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    public class LambdaDelegates : DemoBase
    {

        public delegate void MethodSample(string value);

        public override void Init(List<Product> products)
        {
            #region PREDICATE

            Predicate<int> isParPredicate = NumberIsPar;
            Console.WriteLine(String.Concat("nÚmero Par ? :", isParPredicate(4)));


            //delegate generico que retorna bool conforme regras;
            Predicate<int> pred = (num) => num % 2 == 0;
            Console.WriteLine("Return Predicate(divisao) " + pred(4));


            // retorna somente lsta de pares
            var lista = new int[] { 3,4,6,8,9,10,11,12,14};
            var pares = lista.ToList().FindAll(isParPredicate);


            Console.WriteLine("***********************************************************************************");


            #endregion PREDICATE

            MethodSample MethodSample = (v) => Console.WriteLine("Executando Metodo delegate: " + v);
            MethodSample("chamada delegate executada.");
            Console.WriteLine("***********************************************************************************");


            #region ACTION
            //***********************************************************
            // delegate Generico sem Retorno
            Action<string> DelegateGenerico = (v) =>
            {
                Console.WriteLine(" Nome:" + v);
            };


            Action<Entities.Product> act = UpdatePrices;

            #endregion ACTION

            DelegateGenerico("Paulo Pitte");
            //**********************************************************
            Console.WriteLine("***********************************************************************************");


            //************************************************
            CallDelegate((n) =>
            {
                Console.WriteLine("Calling Delegate : " + n);
                return n.Length;
            });
            //***************************************************

            Console.WriteLine("***********************************************************************************");

          

            ///Referecia simples de metodo com parametro
            // products.Sort(CompareProducts);
            Console.WriteLine("***********************************************************************************");



            Comparison<Product> comparer = CompareProducts;
            products.Sort(comparer);

            Console.WriteLine("***********************************************************************************");

            ///Em programação funcional, expressão lambda corresponde a uma função anônima de primeira classe.
            ///Referenca lambda inline
            products.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));



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



        }

        static int CompareProducts(Entities.Product p1, Entities.Product p2)
            => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());



        static void UpdatePrices(Entities.Product p)
            => p.Price += p.Price * 0.5;

        static string NameUpper(Entities.Product p)
            => p.Name.ToUpper();




        static void CallDelegate(Func<string, int> metodoDelegate)
        {
            var st = metodoDelegate("Pitte");
            Console.WriteLine("Count strings =>  " + st);
        }



        static bool NumberIsPar(int value) => value % 2 == 0;
    }
}
