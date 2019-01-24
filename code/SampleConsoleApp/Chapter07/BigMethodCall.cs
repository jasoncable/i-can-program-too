using System;
namespace SampleConsoleApp.Chapter07
{
    public class BigMethodCall
    {
        public static void RunTheShortWay()
        {
            string s = "My String"
                .ToLower()
                .ToUpper()
                .Replace(" ", "")
                .PadRight(50)
                .Trim()
                .IndexOf('S')
                .ToString();
            Console.WriteLine(s);
        }

        public static void RunTheLongWay()
        {
            string a = "My String";
            string b = a.ToLower();
            string c = b.ToUpper();
            string d = c.Replace(" ", "");
            string e = d.PadRight(50);
            string f = e.Trim();
            int g = f.IndexOf('S');
            string s = g.ToString();
            Console.WriteLine(s);
        }
    }
}
