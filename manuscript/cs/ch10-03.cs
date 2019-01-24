public static class Events
{
    public static void RunMe()
    {
        Publisher p = new Publisher();
        Subscriber s = new Subscriber();

        p.RaiseEvent += s.HandleEvent;
        p.FireOffEvent();
        p.RaiseEvent -= s.HandleEvent;
    }
}

public class Publisher
{
    public event EventHandler RaiseEvent;

    public void FireOffEvent()
    {
        RaiseEvent?.Invoke(this, EventArgs.Empty);
    }
}

public class Subscriber
{
    public void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Handled!");
    }
}