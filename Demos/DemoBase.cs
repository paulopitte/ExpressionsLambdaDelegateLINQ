using Entities;
using System;
using System.Collections.Generic;

namespace Demos
{
    public abstract class DemoBase
    {
        public abstract void Init(List<Product> products);

        public static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
    }
}
