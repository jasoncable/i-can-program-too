using System;
using FluentAssertions;

namespace SampleConsoleApp.Chapter07
{
    public class OutKeyword
    {
        public static void RunIt()
        {
            int convertedInt;
            bool itWorked = Int32.TryParse("123", out convertedInt);
            convertedInt.Should().Be(123);
            itWorked.Should().BeTrue();

            if( Int32.TryParse("456", out int convertedInt1) )
            {
                convertedInt1.Should().Be(456);
            }
            convertedInt1.Should().Be(456);


            TimesFive(5, out var theAnswer);
            theAnswer.Should().BeOfType(typeof(int));
            theAnswer.Should().Be(25);

            TimesTen(out var oneHundred, 10);
            oneHundred.Should().Be(100);
            
        }

        public static void TimesFive(int howMany, out int theAnswer)
        {
            theAnswer = 5 * howMany;
        }

        public static void TimesTen(out int theAnswer, int howMany)
        {
            theAnswer = 10 * howMany;
        }

    }
}
