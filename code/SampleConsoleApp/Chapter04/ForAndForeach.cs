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
        }
    }
}
