using System;
using System.Globalization;

namespace ExpressionsLambdaDelegateLINQ.Entities
{
    public class Product  //: IComparable<Product>
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }



        public override string ToString()
        {
            return Id
                + ", "
                + Name
                + ", "
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + Category.Name
                + ", "
                + Category.Tier;
        }


        //IComparable

        //public int CompareTo(Product other)
        //=> Name.ToUpper().CompareTo(other.Name.ToUpper());





    }
}
