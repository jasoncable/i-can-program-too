using System;
namespace SampleConsoleApp.Chapter02
{
    public static class AddingInVariables
    {
       public static void DoMath()
        {
            int x = 1; // create an int and assign it the value 1
            Console.WriteLine(x);
            int y = 2; // create an int and assign it the value 2
            Console.WriteLine(y);
            y = x + 5; // set y equal to the value in x plus 5
            Console.WriteLine(y);
            // y is now 6
            y = y + 1; // set y equal to the value of y \(6\) plus 1
            Console.WriteLine(y);
            // y is now 7
            int z = x + y; // add x and y and assign them to the new variable z, an int
            Console.WriteLine(z);
            // z is 8
            int a = z * 5; // multiple z by 5 and assign it to a
            Console.WriteLine(a);
            // a is 40
            int b = z * 4 - 32 / 8;  // remember you order of operations from math!
            Console.WriteLine(b);
            // b is 
            int c = b * (2 - 3) * (16 / 8);
            Console.WriteLine(c);
        }
    }
}
