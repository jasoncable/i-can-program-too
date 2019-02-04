using System;
namespace SampleConsoleApp.Chapter11b
{
    public class InstrumentsWithInterfaces
    {
        public static void RunMe()
        {
        }
    }

    public abstract class Instrument
    {
        public string Name { get; protected set; }

        public abstract void Play();

        public sealed override string ToString()
        {
            return Name;
        }
    }

    public abstract class StringInstrument : Instrument
    {
        protected StringInstrument()
        {
            base.Name = "String Instrument";
        }

        public abstract void Pluck();
    }

    public class Violin : StringInstrument
    {
        public Violin() : base()
        {
            base.Name = "Violin";
        }

        public sealed override void Play() { }

        public override void Pluck() { }
    }

    public class Piano : StringInstrument
    {
        public Piano() : base()
        {
            base.Name = "Piano";
        }

        public sealed override void Play() { }

        public sealed override void Pluck()
        {
            throw new Exception("I'm not usually plucked.");
        }

        public void Strike() { }
    }

    public class ConcertGrandPiano : Piano
    {
        public ConcertGrandPiano() : base()
        {
            base.Name = "Concert Grand Piano";
        }
    }

}
