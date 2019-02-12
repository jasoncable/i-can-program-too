using System;
namespace SampleConsoleApp.Chapter12
{
    public class Structs
    {
        public static void RunMe()
        {
            Console.WriteLine(typeof(PreDecimalAmount).BaseType.ToString());

            PreDecimalAmount pda = default(PreDecimalAmount);

        }
    }

    public struct PreDecimalAmount
    {
        public int Pounds { get; set; }
        public int Shillings { get; set; }
        public int Pence { get; set; }
    }
}
