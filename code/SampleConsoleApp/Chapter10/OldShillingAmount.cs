using System;
namespace SampleConsoleApp.Chapter10
{
    public class OldShillingAmount
    {
        public static readonly int NumberOfPence = 12;

        public int Count { get; set; }

        public OldShillingAmount(int shillings) => Count = shillings;

        public int ToPence()
        {
            return Count * NumberOfPence;
        }
    }
}
