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
        public string FullName = "Jason L. Cable";

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

            Name name = new Name();

            name.FullName.Should().Be("Jason L. Cable");
            ChangeFullName(name);
            name.FullName.Should().Be("My New Full Name");

            name = new Name();
            name.FullName.Should().Be("Jason L. Cable");
            ChangeFullNameByRef(ref name);
            name.FullName.Should().Be("Another New Full Name");

            name = new Name();
            name.FullName.Should().Be("Jason L. Cable");
            name.FullName = "A 4th Full Name";
            ReassignName(name);
            name.FullName.Should().Be("A 3rd New Full Name");

            name = new Name();
            name.FullName.Should().Be("Jason L. Cable");
            ReassignNameByRef(ref name);
            name.FullName.Should().Be("A 5th New Full Name");


            // ----- //

            Name a = new Name();
            Name b = a;
            Name c = b;
            a.Should().BeSameAs(b);
            b.Should().BeSameAs(c);
            a.FullName.Should().Be("Jason L. Cable");
            b.FullName = "Full Name #1";
            b.FullName.Should().Be("Full Name #1");
            a.FullName.Should().Be("Full Name #1");
            c.FullName.Should().Be("Full Name #1");
            b = new Name();
            b.FullName.Should().Be("Jason L. Cable");
            a.FullName.Should().Be("Full Name #1");
            c.FullName.Should().Be("Full Name #1");

            int x = 1;
            int y = x;
            int z = y;
            x.Should().Be(1);
            y.Should().Be(1);
            z.Should().Be(1);
            x = 10;
            y = 20;
            z = 30;
            x.Should().Be(10);
            y.Should().Be(20);
            z.Should().Be(30);

            // ----- //


        }

        public static void ReassignNameByRef(ref Name name)
        {
            name = new Name();
            name.FullName.Should().Be("Jason L. Cable");
            name.FullName = "A 5th New Full Name";
            name.FullName.Should().Be("A 5th New Full Name");
        }

        public static void ReassignName(Name name)
        {
            name.FullName = "A 3rd New Full Name";
            name = new Name();
            name.FullName.Should().Be("Jason L. Cable");
        }

        public static void ChangeFullNameByRef(ref Name name)
        {
            name.FullName = "Another New Full Name";
        }

        public static void ChangeFullName(Name name)
        {
            name.FullName = "My New Full Name";
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
