using System;
using System.Globalization;

namespace ExpressionsLambdaDelegateLINQ.Entities
{
    class Product  //: IComparable<Product>
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }


        public override string ToString()
         => String.Concat(Name, " - ", Price.ToString("F2", CultureInfo.InvariantCulture));



        //IComparable

        //public int CompareTo(Product other)
        //=> Name.ToUpper().CompareTo(other.Name.ToUpper());





    }
}
