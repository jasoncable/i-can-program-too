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

public abstract class Instrument : IPlayable
{
    public string Name { get; protected set; }
    public abstract void Play();
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
    public sealed override void Play() { }
    public void Pluck() { }
    public void Strike() { }
}

public class ConcertGrandPiano : Piano
{
    public ConcertGrandPiano() : base()
    {
        base.Name = "Concert Grand Piano";
    }
}