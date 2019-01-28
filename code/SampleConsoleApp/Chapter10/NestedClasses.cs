using System;
namespace SampleConsoleApp.Chapter10
{
    public class NestedClasses
    {
        public static void RunMe()
        {
            ClassE a = new ClassE();
            a.MyClassF.PrintClassName();
        }
    }

    public class ClassA
    {
        private string _className = "Class A";

        public class ClassB
        {
            public void PrintClassName()
            {
                //Console.WriteLine(_className);
            }
        }
    }

    public static class ClassC
    {
        public static class ClassD
        {

        }
    }

    public class ClassE
    {
        private string _className = "Class A";
        public ClassF MyClassF { get; set; }

        public ClassE()
        {
            MyClassF = new ClassF(this);
        }

        public class ClassF
        {
            private ClassE _parent;

            public ClassF(ClassE instance)
            {
                _parent = instance;
            }

            public void PrintClassName()
            {
                Console.WriteLine(_parent._className);
            }
        }
    }
}
