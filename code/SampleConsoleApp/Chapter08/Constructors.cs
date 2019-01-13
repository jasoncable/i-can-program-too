using System;
namespace SampleConsoleApp.Chapter08
{
    public class Constructors
    {
        public static void RunTests()
        {
            var c1 = new GraphPoint2();
        }
    }

    public class Constructor1
    {
        public Constructor1()
        {
            Console.WriteLine("default constructor");
        }

        public Constructor1(string s) : this()
        {
            Console.WriteLine("string constructor");
        }
    }

    public class GraphPoint
    {
        private int x;
        private int y;

        public GraphPoint() : this(0, 0)
        {
        }

        public GraphPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class GraphPoint1
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GraphPoint1()
        {
            this.X = 0;
            this.Y = 0;
        }

        public GraphPoint1(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class GraphPoint2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GraphPoint2() : this(0, 0)
        {
            Console.WriteLine("default");
        }

        public GraphPoint2(int x, int y)
        {
            Console.WriteLine("two");
            this.X = x;
            this.Y = y;
        }
    }

    public class PrivateConstructor
    {
        private PrivateConstructor() { }

        public PrivateConstructor CreateInstance()
        {
            return new PrivateConstructor();
        }
    }
}
