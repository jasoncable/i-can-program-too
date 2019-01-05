using System;
namespace SampleConsoleApp.Chapter04
{
    public class ForAndForeach
    {
        public static void LoopMe()
        {
            string[] sa = { "a", "b", "c", "d" };
            for ( int i = 0; i < sa.Length; i++)
            {
                Console.WriteLine(sa[i]);
            }

            Console.WriteLine();

            for (int i = 0, j = 0; i < sa.Length; i++, j++)
            {
                Console.WriteLine(sa[i]);
            }

            Console.WriteLine();

            for( int i = sa.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(sa[i]);
            }

            Console.WriteLine();

            string[] sa1 = { "a", "b", "c", "d" };
            bool foundAMatch = false;
            for (int i = 0; i < sa1.Length; i++)
            {
                if (sa1[i] == "c")
                {
                    foundAMatch = true;
                    break;
                }
            }
            if (foundAMatch)
            {
                Console.WriteLine("Match found!");
            }

            Console.WriteLine();


            var sa3 = new string[] { "a", "b", "c", "d" };
            //var sa2 = { "a", "b", "c", "d" };
            foreach (string s1 in sa3)
            {
                Console.WriteLine(s1);
            }

            var int2 = 4;
            var s5 = "my string";

            Console.WriteLine($"{int2} {s5}");
        }
    }
}
