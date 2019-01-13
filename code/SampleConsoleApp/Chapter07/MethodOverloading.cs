using System;
namespace SampleConsoleApp.Chapter07
{
    public class MethodOverloading
    {
        public static void RunMe()
        {
            int a = Convert.ToInt32("123");
            int b = Convert.ToInt32(true);
            int c = Convert.ToInt32(123.92m);
            // and 16 others, as defined by .NET Standard
        }
    }
}
