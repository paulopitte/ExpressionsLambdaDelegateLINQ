using Entities;
using System;

namespace Demos
{
    public class GetHashCodeEhEquals
    {
        public void Init()
        {

            Client a = new() { Email = "paulopitte@gmail.com", Name = "PauloPitte" };
            Client b = new() { Email = "paulopitte@gmail.com", Name = "PauloSMPitte" };


            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
        }
    }
}
