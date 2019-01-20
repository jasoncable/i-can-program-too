using System;
namespace SampleConsoleApp.Chapter08
{
    public class StaticConstructor
    {
        public static readonly DateTime DateStarted;

        static StaticConstructor()
        {
            DateStarted = DateTime.Now;
        }
    }
}