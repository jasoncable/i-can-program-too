using System;

namespace SampleConsoleApp.Chapter07
{
    public class MethodTests
    {

        //public static void Method1(
        //    int i = Int32.MaxValue,
        //    DateTime dt = DateTime.MaxValue,
        //    DateTime dt1 = new DateTime(),
        //    Guid g = Guid.Empty,
        //    Guid g1 = new Guid(),
        //    Guid g2 = Guid.NewGuid(),
        //    string s = String.Empty,
        //    string s1 = default(string)
        //   //DateTime dt2 = DateTime.MinValue
        //)
        //{ }

        public static void RunTests()
        {
            string myName = GetName("Jason", last: "Cable", middle: "L.");
            Console.WriteLine(myName);

            string myOtherName = GetNameAgain(last: "Public");
            Console.WriteLine(myOtherName);

            var yetAnotherName = GetName(first: "Jason", "L.", last: "Cable");
            Console.WriteLine(yetAnotherName);
        }

        public static string GetName(
            string first,
            string middle,
            string last)
        {
            return $"{first} {middle} {last}";
        }

        public static string GetNameAgain(
            string first = "John",
            string middle = "Q.",
            string last = "Doe")
        {
            //return String.Format("{0} {1} {2}", first, middle, last);
            return $"{first} {middle} {last}";
        }
    }
}
