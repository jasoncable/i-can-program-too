using System;
namespace SampleConsoleApp.Chapter11
{
    public class MyObject : Object
    {
        public MyObject() : base()
        {

        }

        public override string ToString()
        {
            return "This is my class.";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
