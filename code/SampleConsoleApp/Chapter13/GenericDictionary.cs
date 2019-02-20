using System;
using System.Collections.Generic;

namespace SampleConsoleApp.Chapter13
{
    public class GenericDictionary
    {
        public static void RunMe()
        {
            Dictionary<string, string> cities = new Dictionary<string, string>(4);
            cities.Add("15206", "Pittsburgh");
            cities.Add("15108", "Moon Township");
            cities.Add("15222", "Pittsburgh");
            cities.Add("16365", "Warren");

            cities["15232"] = "Shadyside";
            cities["15222"] = "Pittsburgh";
            cities["15232"] = "Pittsburgh";

            string keyToFind = "11111";

            if (cities.ContainsKey(keyToFind))
                Console.WriteLine(cities[keyToFind]);

            if (cities.TryGetValue("1111", out string theValue))
                Console.WriteLine(theValue);

            if (cities.TryAdd("15221", "Not Pittsburgh"))
                Console.WriteLine("success");
        }
    }
}
