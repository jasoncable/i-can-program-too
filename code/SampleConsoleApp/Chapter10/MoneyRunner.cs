using System;
using FluentAssertions;

namespace SampleConsoleApp.Chapter10
{
    public static class MoneyRunner
    {
        public static void Run()
        {
            var pdA = new PreDecimalAmount(1, 1, 1);
            var pdB = new PreDecimalAmount(3, 18, 11);

            var pdAdd = pdA + pdB;
            pdAdd.Pounds.Count.Should().Be(5);
            pdAdd.Shillings.Count.Should().Be(0);
            pdAdd.Pence.Count.Should().Be(0);
        }
    }
}
