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

            AccessLevel al = AccessLevel.Reader | AccessLevel.Writer;

            if((al & AccessLevel.Reader) == AccessLevel.Reader)
            { 
                Console.WriteLine("Got it!"); 
            }

            AccessLevel al1 = AccessLevel.None;
            al1 |= AccessLevel.Reader;
            al1 |= AccessLevel.Writer;

            AccessLevel al2 = AccessLevel.Reader | AccessLevel.Writer;
            al2 &= ~AccessLevel.Writer;

            Console.WriteLine(al.HasFlag(AccessLevel.Admin));

            Console.WriteLine(StringLib.Language);
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

    public static class StringLib
    {
        public static readonly string VersionNo = "8.0.0";
        public static readonly string Language = "C#";
    }
}
