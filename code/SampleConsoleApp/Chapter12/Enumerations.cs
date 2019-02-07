using System;
namespace SampleConsoleApp.Chapter12
{
    public class Enumerations
    {
        public static void RunMe()
        {
            PianoType pt = PianoType.FullConcertGrand;

            if (pt == PianoType.FullConcertGrand) { }

            pt.ToString(); 
            // returns "FullConcertGrand"

            int i = (int)pt;
            // i == 3

            PianoType pt1 = (PianoType)1;
        }
    }

    public enum PianoType
    {
        Upright,
        BabyGrand,
        FullConcertGrand
    }
}
