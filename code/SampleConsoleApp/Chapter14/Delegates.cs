using System;
using System.Collections.Generic;

namespace SampleConsoleApp.Chapter14
{
    public class Delegates
    {
        private delegate int myDelegate(int x, int y);
        public static void RunMe()
        {
            myDelegate addIt = (x, y) => x + y;
            int z = addIt(123, 321);

            Action<List<string>> printer = x =>
            {
                foreach (var str in x) Console.WriteLine(str);
            };
            List<string> strings = new List<string> { "A", "B", "C" };
            printer(strings);

            Printer(DateTime.Now);
        }

        public static void Printer<T>(T input) => 
            Console.WriteLine(input.ToString());
    }
}
