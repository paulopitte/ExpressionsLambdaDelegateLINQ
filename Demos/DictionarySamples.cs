using Entities;
using System.Collections.Generic;

namespace Demos
{
    public class DictionarySamples
    {
        public void Init()
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs["user"] = "Paulo";
            keyValuePairs["email"] = "paulopitte@gmail.com";
            keyValuePairs["phone"] = "11986681101";
            keyValuePairs["phone"] = "1147994151"; // sobrescreve;
            keyValuePairs.Remove("email");


            System.Console.WriteLine();
            System.Console.WriteLine(keyValuePairs["user"]);


            if (keyValuePairs.ContainsKey("email"))
                System.Console.WriteLine(keyValuePairs["user"]);
            else
                System.Console.WriteLine("Email removido");



            foreach (KeyValuePair<string, string> item in keyValuePairs)
                System.Console.WriteLine(item.Key + " - " + item.Value);

        }
    }
}
