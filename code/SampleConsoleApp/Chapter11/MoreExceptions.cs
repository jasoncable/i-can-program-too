using System;
namespace SampleConsoleApp.Chapter11
{
    public class MoreExceptions
    {
        public static void RunMe()
        {
            throw new MyException("my exception");
        }
    }

    public class MyException : Exception
    {
        private string _message;

        public MyException(string message) => _message = message;

        public override string Message => _message;
    }
}
