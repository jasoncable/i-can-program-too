using System;
namespace SampleConsoleApp.Chapter03
{
    public class AddingNullableNumbers
    {
       public static void AddIt()
        {
            int? i = 123;
            int? j = 321;
            int? k = null;
            int x = 12;
            int y = 21;

            // nullable + nullable
            Console.WriteLine(i + j);

            // nullable + non-nullable
            Console.WriteLine(i + x);

            // non-nullable + nullable
            Console.WriteLine(x + i);

            // null + nullable
            Console.WriteLine(k + i);

            // nullable + null
            Console.WriteLine(i + k);

            // null + non-null
            Console.WriteLine(k + y);

            // non-null + null
            Console.WriteLine(y + k);

        }
    }
}
