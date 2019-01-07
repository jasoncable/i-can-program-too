using System;
using FluentAssertions;

namespace SampleConsoleApp.Chapter07
{
    public class Name
    {
        private string _firstName = "Jason";
        private string _lastName = "Cable";
        private int _i = 0;
        private string s = "lee";

        public string MakeUpperS(string s)
        {
            return s.ToUpper();
        }
    }

    public class ByRefByVal
    {
        public static void RunTests()
        {
            int i = 0;

            IncrementByPlusEquals(i);
            i.Should().Be(0);

            i = 0;
            IncrementWithPre(i);
            i.Should().Be(0);

            i = 0;
            IncrementWithPost(i);
            i.Should().Be(0);

            i = 0;
            IncrementByPlusEqualsRef(ref i);
            i.Should().Be(1);

            i = 0;
            IncrementWithPreRef(ref i);
            i.Should().Be(1);

            i = 0;
            IncrementWithPostRef(ref i);
            i.Should().Be(1);
        }

        public static void IncrementByPlusEquals(int i)
        {
            i += 1;
        }

        public static void IncrementWithPre(int i)
        {
            ++i;
        }

        public static void IncrementWithPost(int i)
        {
            i++;
        }

        public static void IncrementByPlusEqualsRef(ref int i)
        {
            i += 1;
        }

        public static void IncrementWithPreRef(ref int i)
        {
            ++i;
        }

        public static void IncrementWithPostRef(ref int i)
        {
            i++;
        }

    }
}
