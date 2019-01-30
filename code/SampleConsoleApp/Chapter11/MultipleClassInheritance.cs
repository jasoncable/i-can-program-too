using System;
using FluentAssertions;

namespace SampleConsoleApp.Chapter11
{
    public class MultipleClassInheritance
    {
        public static void RunMe()
        {
            Piano p = new Piano();
            Console.WriteLine(p.Name);
            Console.WriteLine(p.ToString());

            Instrument[] ia = new Instrument[2];
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


        }

        public static void PartyTime(Instrument instrument)
        {
            instrument.Play();
        }
    }

    public class Instrument
    {
        public string Name { get; protected set; }

        public virtual void Play() { }

        public override string ToString()
        {
            return Name;
        }
    }

    public class StringInstrument : Instrument
    {
        public StringInstrument()
        {
            base.Name = "String Instrument";
        }

        public virtual void Pluck() { }
    }

    public class Violin : StringInstrument
    {
        public Violin() : base()
        {
            base.Name = "Violin";
        }

        public override void Play() { }

        public override void Pluck() { }
    }

    public class Piano : StringInstrument
    {
        public Piano() : base()
        {
            base.Name = "Piano";
        }

        public override void Play() { }

        public override void Pluck()
        {
            throw new Exception("I'm not usually plucked.");
        }

        public void Strike() { }
    }
}
