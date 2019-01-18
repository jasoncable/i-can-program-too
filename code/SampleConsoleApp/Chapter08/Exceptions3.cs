using System;
namespace SampleConsoleApp.Chapter08
{
    public class MyException: Exception
    {
        public MyException()
        {
            this.HResult = 123;
        }
    }

    public class Exceptions3
    {
       public static void RunMe()
        {
            try
            {
                throw new ApplicationException("Yippee!");
            }
            catch(Exception exc) when (exc.HResult == 123)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
