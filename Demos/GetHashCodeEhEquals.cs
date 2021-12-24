using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    public class GetHashCodeEhEquals
    {


    }


    public class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Client)) return false;

            var client = obj as Client;
            return Email.ToLower().Equals(client.Email.ToLower()); //&& Name.ToLower().Equals(client.Name.ToLower());
        }

    }
}
