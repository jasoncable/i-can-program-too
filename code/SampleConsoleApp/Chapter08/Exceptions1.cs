using System;
namespace SampleConsoleApp.Chapter08
{
    public class Exceptions1
    {
        public static void StrToNo()
        {
            string line;
            while ((line = Console.ReadLine()) != String.Empty)
            {
                try
                {
                    Console.WriteLine($"input:  {line}");
                    int i = Convert.ToInt32(line);
                    Console.WriteLine($"Int32: {i}");
                }
                catch(FormatException exc)
                {
                    Console.WriteLine(exc.ToString());
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
                finally
                {
                    Console.WriteLine("Next or done?");
                }
            }
            Console.WriteLine("Really, really done!");
        }
    }
}