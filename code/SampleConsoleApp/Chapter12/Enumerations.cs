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

            PianoType pt0 = (PianoType)5;

            Console.WriteLine(pt0.ToString());

            Console.WriteLine(Enum.IsDefined(typeof(PianoType), "Upright"));

            PianoType pt5;
            if (Enum.TryParse(typeof(PianoType), "Upright", out object pt3))
                pt5 = (PianoType)pt3;
            else
                pt5 = PianoType.None;

            PianoType? pt6 = null;


        }
    }

    public enum PianoType
    {
        None = 0,
        Upright = 1,
        BabyGrand,
        FullConcertGrand
    }

    [Flags]
    public enum InstrumentFamily
    {
        None = 0,
        String = 1,
        Percussion = 2,
        Woodwind = 4,
        Brass = 8
    }

    [Flags]
    public enum AccessLevel
    {
        None = 0,
        Admin = 1,
        Reader = 2,
        Writer = 4,
        Commenter = 8,
        All = Admin | Reader | Writer | Commenter
    }
}
