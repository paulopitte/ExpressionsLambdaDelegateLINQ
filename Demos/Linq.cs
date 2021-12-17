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

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900:", r1);

        }

     }
}
