using System;
using FluentAssertions;

namespace SampleConsoleApp.Chapter11a
{
    public class InstrumentsWithAbstract
    {
        public static void RunMe()
        {
            Piano p = new Piano();
            Console.WriteLine(p.Name);
            Console.WriteLine(p.ToString());

            Instrument[] ia = new Instrument[3];
            ia[0] = new Violin();
            ia[1] = new Piano();

            ia[0].Should().BeOfType<Violin>();
            ia[0].Should().BeAssignableTo<StringInstrument>();

            object o = new Piano();

            Piano myPiano = (Piano)ia[1];

            Violin myViolin = ia[1] as Violin;
            myViolin.Should().BeNull();

            bool isPiano = ia[0] is Piano;
            isPiano.Should().BeFalse();

            bool isAnotherPiano = ia[0].GetType() == typeof(Piano);
            isAnotherPiano.Should().BeFalse();

            //bool isAStringInstrument = ia[0].GetType().IsAssignableFrom(typeof(Violin));

            bool isAThirdPiano = typeof(Piano).IsInstanceOfType(ia[0]);
            isAThirdPiano.Should().BeFalse();


            Piano myPianoNull = (Piano)ia[2]; // null
            Violin myViolinNull = ia[2] as Violin; // null
            bool isPianoNull = ia[2] is Piano; // false
            //bool isAnotherPianoNull = ia[2].GetType() == typeof(Piano); // exception
            bool isAThirdPianoNull = typeof(Piano).IsInstanceOfType(ia[2]); // false

            Console.WriteLine();
        }
    }

    public abstract class AbstractTest
    {
        public abstract string StringProp { get; set; }
        public abstract void RunMe();
    }

    // ----------- //

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
