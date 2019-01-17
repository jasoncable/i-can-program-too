public class Runner
{
    public static void Execute()
    {
        ExceptionsA.DoSomething("ABC");
    }
}

public class ExceptionsA
{
    public static string DoSomething(string s)
    {
        try
        {
            return ExceptionsB.DoSomething(s);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc);
        }
        return null;
    }
}

public class ExceptionsB
{
    public static string DoSomething(string s)
    {
        try
        {
            return ExceptionsC.DoSomething(s);
        }
        catch
        {
            throw;
        }
    }
}

public class ExceptionsC
{
    public static string DoSomething(string s)
    {
        try
        {
            return s.Substring(0, 10);
        }
        catch
        {
            throw;
        }
    }
}