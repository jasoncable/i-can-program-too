using System;

namespace SampleConsoleApp.Chapter11b
{
    public class InstrumentsWithInterfaces
    {
        public static void RunMe()
        {
            Instrument[] tinyOrchestra =
            {
                new Violin(),
                new Violin(),
                new ConcertGrandPiano()
            };

            foreach (IPlayable playIt in tinyOrchestra)
            {
                if (playIt is IStringInstrument)
                    playIt.Play();
            }

            foreach(Instrument instrument in tinyOrchestra)
            {
                Piano p = instrument as Piano;
                if(p != null)
                {
                    Console.WriteLine($"{p.Name}");
                }
            }
        }
    }

    public interface IStringInstrument
    {
        void Pluck();
    }

    public interface IPercussionInstrument
    {
        void Strike();
    }

    public interface IPlayable
    {
        void Play();
    }

    //public interface IPlayableToo : IPlayable
    //{
    //    void PlayAgain();
    //}

    public abstract class Instrument : IPlayable //IPlayableToo
    {
        public string Name { get; protected set; }

        public abstract void Play();
        //public abstract void PlayAgain(); 

        public sealed override string ToString()
        {
            return Name;
        }
    }

    public class Violin : Instrument, IStringInstrument
    {
        public Violin() : base()
        {
            base.Name = "Violin";
        }

        public sealed override void Play() { }

        public void Pluck() { }
    }

    public class Piano : Instrument, IStringInstrument, IPercussionInstrument
    {
        public Piano() : base()
        {
            base.Name = "Piano";
        }


        public sealed override void Play() { }  //Console.WriteLine("sealed"); }

        public void Pluck()
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

        //public new void Play() { Console.WriteLine("new"); }
    }

}
