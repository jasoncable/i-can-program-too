using System;
namespace SampleConsoleApp.Chapter08
{
    public class Exceptions
    {
        public static string BadIndex()
        {
            string[] sa = { "a", "b", "c", "d" };
            return sa[5];
        }

        public static void Int32Exception()
        {
            Convert.ToInt32("123abc");
        }

        public static int StringFormat(string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch(FormatException exc)
            {
                Console.WriteLine(exc.ToString());
                return 0;
            }
        }
    }
}
