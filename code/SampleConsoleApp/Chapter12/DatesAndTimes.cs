using System;
namespace SampleConsoleApp.Chapter12
{
    public class DatesAndTimes
    {
        public static void RunMe() {
            DateTime epoch = new DateTime(1970, 1, 1);
            DateTime birthDay = new DateTime(1980, 3, 3, 19, 5, 0);
            TimeSpan ts = birthDay - epoch;
            long epochTime = (long)ts.TotalSeconds;
            Console.WriteLine(epochTime);
            DateTime birthDayFromEpoch = new DateTime(1970, 1, 1).AddSeconds(320958300l);
            Console.WriteLine(birthDayFromEpoch.ToString());
        }
    }
}
