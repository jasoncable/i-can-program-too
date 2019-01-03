using System;
namespace SampleConsoleApp.Chapter04
{
    public class DoWhileWhileDo
    {
        public static void RunMe()
        {
            Console.WriteLine("while-do");
            int currentLoopCount = 0;
            while (currentLoopCount < 5)
            {
                currentLoopCount++;
                Console.WriteLine(currentLoopCount);
            }
            Console.WriteLine($"final: {currentLoopCount}");

            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("do-while");
            currentLoopCount = 0;
            do
            {
                currentLoopCount++;
            }
            while (currentLoopCount < 5);
            Console.WriteLine($"final: {currentLoopCount}");

            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("I is odd?");
            int i = 1;
            while (++i <= 1000)
            {
                if (i % 2 == 0)
                    continue;
                Console.WriteLine($"{i} - I is odd");
            }
            Console.WriteLine(); Console.WriteLine();

        }
    }
}
