using System;
using System.Collections.Generic; // don't forget!
using System.Globalization; // here's a new one!

public class MWSort : IComparer<string>
{
    private StringComparer comparer;

    public MWSort()
    {
        CultureInfo ci = new CultureInfo("en-US", true);
        comparer = ci.CompareInfo
            .GetStringComparer(
                CompareOptions.IgnoreCase |
                CompareOptions.IgnoreSymbols);
    }

    public int Compare(string x, string y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;

        return comparer.Compare(x, y);
    }
}

List<string> words = new List<string>
{
    "life",
    "life belt",
    "life support",
    "life-and-death",
    "life-support",
    "lifeblood",
    "LIFO"
};

words.Sort(new MWSort());

foreach (var word in words)
    Console.WriteLine(word);