using System;
using System.Collections.Generic;

namespace SampleConsoleApp.Chapter14
{
    public class Delegates
    {
        private delegate int myDelegate(int x, int y);
        public static void RunMe()
        {
            myDelegate addIt = (x, y) => x + y;
            int z = addIt(123, 321);

            Action<List<string>> printer = x =>
            {
                foreach (var str in x) Console.WriteLine(str);
            };
            List<string> strings = new List<string> { "A", "B", "C" };
            printer(strings);

            Printer(DateTime.Now);

            Printer<DateTime>(DateTime.Now);

            List<string> myStrings = new List<string> { "C", "B", "A" };
            myStrings.SortAndRunEach(x => Console.WriteLine(x));
            Console.WriteLine(myStrings[0]);

            Func<int, int, int> kaPow = (x, y) => (int)Math.Pow(x, y);
            int result = kaPow(2, 18);

            TestClass tc1 = new TestClass();
            TestClass tc2 = new TestClass();
            Console.WriteLine(tc1.Equals(tc2));
            Console.WriteLine(AreEqual(tc1, tc2));
            Console.WriteLine(tc1.Equals((object)tc2));
            bool b1 = tc1.Equals(tc2);
            bool b2 = AreEqual(tc1, tc2);
        }

        public static void Printer<T>(T input) => 
            Console.WriteLine(input.ToString());

        public static bool MightBeEqual<T>(T arg1, T arg2) where T : class
        {
            return arg1 == arg2;
        }

        public static bool AreEqual<T>(T arg1, T arg2)
            where T : IEquatable<T>
        {
            return arg1.Equals(arg2);
        }

        public bool IsTrue<T>(T someThing)
            where T : class, IList<T>, new()
        {
            return true;
        }
    }

    public class TestClass : IEquatable<TestClass>
    {
        public int Value { get; set; } = 42;

        public bool Equals(TestClass other)
        {
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || this.GetType() != obj.GetType())
        //    //if (obj == null || !(obj is IEquatable<TestClass>))
        //        return false;
        //    else
        //        return this.Equals((TestClass)obj);
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj is TestClass)
        //        this.Equals((TestClass)obj);
        //    else
        //        return false;
        //}

        public override bool Equals(object obj)
        {
            if (obj is TestClass tc)
                return Equals(tc);
            else
                return false;
        }

    }

    public static class Extensions
    {
        public static void SortAndRunEach(
            this List<string> input,
            Action<string> actionToPerform)
        {
            if (input == null)
                throw new ArgumentException($"{nameof(input)}: argument null");

            if(actionToPerform == null)
                throw new ArgumentException(
                    $"{nameof(actionToPerform)}: argument null"
                );

            var sorted = new List<string>(input);
            sorted.Sort();

            foreach(var s in sorted)
            {
                actionToPerform(s);
            }
        }

    }

}
